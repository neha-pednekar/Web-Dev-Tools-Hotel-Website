using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectNehaPalace.Data;
using ProjectNehaPalace.HelperMethods;
using ProjectNehaPalace.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectNehaPalace.Controllers
{
    public class HotelController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:51947/api/rooms";
        RoomClient roomClient = new RoomClient("http://localhost:50254");
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Reservation()
        {
            if (ModelState.IsValid)
            {
                Booking booking = null;
                var user = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

                if (!String.IsNullOrWhiteSpace(user.UserName))
                {

                    var mostRecentPreBookingInfo = _context.PreBookingInfo
                                                    .Where(pb => pb.LoggedInUserName == user.UserName)
                                                    .OrderByDescending(x => x.DateEntered)
                                                    .Select(m => m)
                                                    .FirstOrDefault();

                    if(mostRecentPreBookingInfo != null)
                    {
                        booking = new Booking();
                        booking.CheckinDate = mostRecentPreBookingInfo.CheckinDate;
                        booking.CheckoutDate = mostRecentPreBookingInfo.CheckoutDate;
                        booking.NumberOfAdults = mostRecentPreBookingInfo.NumberOfAdults;
                        booking.NumberOfChildren = mostRecentPreBookingInfo.NumberOfChildren;
                        mostRecentPreBookingInfo.LoggedInUserName = user.UserName;

                        return View("Reservation", booking);
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();
            }
            return View();
                    
        }

        [HttpPost]
        [Authorize]
        public IActionResult Reservation(PreBookingInformation preBookingInformation)
        {
            var booking = new Booking();
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

                if(!String.IsNullOrWhiteSpace(user.UserName))
                {

                    var mostRecentPreBookingInfo = _context.PreBookingInfo
                                                    .Where(pb => pb.LoggedInUserName == user.UserName)
                                                    .OrderByDescending(x => x.DateEntered)
                                                    .Select(m => m)
                                                    .FirstOrDefault();

                    if(mostRecentPreBookingInfo != null)
                    {
                        booking.CheckinDate = mostRecentPreBookingInfo.CheckinDate;
                        booking.CheckoutDate = mostRecentPreBookingInfo.CheckoutDate;
                        booking.NumberOfAdults = mostRecentPreBookingInfo.NumberOfAdults;
                        booking.NumberOfChildren = mostRecentPreBookingInfo.NumberOfChildren;
                        mostRecentPreBookingInfo.LoggedInUserName = user.UserName;
                    }
                    else
                    {
                        booking.CheckinDate = preBookingInformation.CheckinDate;
                        booking.CheckoutDate = preBookingInformation.CheckoutDate;
                        booking.NumberOfAdults = preBookingInformation.NumberOfAdults;
                        booking.NumberOfChildren = preBookingInformation.NumberOfChildren;
                        preBookingInformation.LoggedInUserName = user.UserName;

                        _context.PreBookingInfo.AddAsync(preBookingInformation);
                    }
                }

                _context.SaveChangesAsync();
            }
            
            return View("Reservation", booking);
        }

        [Authorize]
        [HttpGet]
        public IActionResult SaveBookingDates(Booking booking)
        {
            return View(booking);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SaveRoomDetails(Booking booking)
        {
            return View("Reservation", booking);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Confirmation()
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

                if (!String.IsNullOrWhiteSpace(user.UserName))
                {
                    var mostRecentBooking = _context.Booking
                                                    .Where(b => b.Customer.EmailAddress == user.UserName)
                                                    .OrderByDescending(x => x.BookingDate)
                                                    .Select(bk => bk)
                                                    .FirstOrDefault();

                    if (mostRecentBooking != null)
                    {
                        return View("Confirmation", mostRecentBooking);
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Confirmation(Booking booking)
        {
            if (ModelState.IsValid)
            {
                int totalNumberOfDays = 0;
                double totalTariffAmountPerDay = 0.0;
                booking.Room = new List<Room>();

                //First check the availability of the room from the API
                IEnumerable<RoomModel> rooms = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    //HTTP GET
                    var responseTask = client.GetAsync("rooms");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<RoomModel>>();
                        readTask.Wait();

                        rooms = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        rooms = Enumerable.Empty<RoomModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                    //If the rooms are available then go ahead with the booking
                    if (rooms != null && rooms.Count() > 0)
                    {
                        foreach (RoomModel room in rooms)
                        {
                            if (booking.SingleRoom > 0
                             && room.RoomType == RoomType.SingleRoom.ToString()
                             && room.RoomsAvailable >= booking.SingleRoom)
                            {
                                for(int i=0; i<booking.SingleRoom; i++)
                                {
                                    var singleRoom = new Room();

                                    singleRoom.IsAvailable = true;
                                    singleRoom.LastModifiedDate = DateTime.Now;
                                    singleRoom.RoomsSelected = booking.SingleRoom;
                                    singleRoom.RoomTariff = room.RoomTariff;
                                    singleRoom.RoomType = room.RoomType;
                                    singleRoom.TotalNumberOfRoomsAvailable = room.RoomsAvailable;

                                    booking.Room.Add(singleRoom);

                                    room.RoomsAvailable--;
                                    room.RoomsBooked++;

                                    var putTask = client.PutAsJsonAsync<RoomModel>("rooms/SingleRoom", room);
                                    putTask.Wait();

                                    var putResult = putTask.Result;

                                    if (!putResult.IsSuccessStatusCode)
                                    {
                                        ModelState.AddModelError(string.Empty, "Unable to update the API");
                                    }
                                }
                            }
                            else if (booking.DoubleRoom > 0
                             && room.RoomType == RoomType.DoubleRoom.ToString()
                             && room.RoomsAvailable >= booking.DoubleRoom)
                            {
                                for (int i = 0; i < booking.DoubleRoom; i++)
                                {
                                    var doubleRoom = new Room();

                                    doubleRoom.IsAvailable = true;
                                    doubleRoom.LastModifiedDate = DateTime.Now;
                                    doubleRoom.RoomsSelected = booking.DoubleRoom;
                                    doubleRoom.RoomTariff = room.RoomTariff;
                                    doubleRoom.RoomType = room.RoomType;
                                    doubleRoom.TotalNumberOfRoomsAvailable = room.RoomsAvailable;

                                    booking.Room.Add(doubleRoom);

                                    room.RoomsAvailable--;
                                    room.RoomsBooked++;

                                    var putTask = client.PutAsJsonAsync<RoomModel>("rooms/DoubleRoom", room);
                                    putTask.Wait();

                                    var putResult = putTask.Result;

                                    if (!putResult.IsSuccessStatusCode)
                                    {
                                        ModelState.AddModelError(string.Empty, "Unable to update the API");
                                    }
                                }
                            }
                            else if (booking.DeluxeOneBedSuite > 0
                             && room.RoomType == RoomType.DeluxeOneBedroomSuite.ToString()
                             && room.RoomsAvailable >= booking.DeluxeOneBedSuite)
                            {
                                for (int i = 0; i < booking.DeluxeOneBedSuite; i++)
                                {
                                    var deluxeOneBedSuite = new Room();

                                    deluxeOneBedSuite.IsAvailable = true;
                                    deluxeOneBedSuite.LastModifiedDate = DateTime.Now;
                                    deluxeOneBedSuite.RoomsSelected = booking.DeluxeOneBedSuite;
                                    deluxeOneBedSuite.RoomTariff = room.RoomTariff;
                                    deluxeOneBedSuite.RoomType = room.RoomType;
                                    deluxeOneBedSuite.TotalNumberOfRoomsAvailable = room.RoomsAvailable;

                                    booking.Room.Add(deluxeOneBedSuite);

                                    room.RoomsAvailable--;
                                    room.RoomsBooked++;

                                    var putTask = client.PutAsJsonAsync<RoomModel>("rooms/DeluxeOneBedSuite", room);
                                    putTask.Wait();

                                    var putResult = putTask.Result;

                                    if (!putResult.IsSuccessStatusCode)
                                    {
                                        ModelState.AddModelError(string.Empty, "Unable to update the API");
                                    }
                                }
                            }
                            else if (booking.DeluxeTwoBedSuite > 0
                             && room.RoomType == RoomType.DeluxeTwoBedroomSuite.ToString()
                             && room.RoomsAvailable >= booking.DeluxeTwoBedSuite)
                            {
                                for (int i = 0; i < booking.DeluxeTwoBedSuite; i++)
                                {
                                    var deluxeTwoBedSuite = new Room();

                                    deluxeTwoBedSuite.IsAvailable = true;
                                    deluxeTwoBedSuite.LastModifiedDate = DateTime.Now;
                                    deluxeTwoBedSuite.RoomsSelected = booking.DeluxeTwoBedSuite;
                                    deluxeTwoBedSuite.RoomTariff = room.RoomTariff;
                                    deluxeTwoBedSuite.RoomType = room.RoomType;
                                    deluxeTwoBedSuite.TotalNumberOfRoomsAvailable = room.RoomsAvailable;

                                    booking.Room.Add(deluxeTwoBedSuite);

                                    room.RoomsAvailable--;
                                    room.RoomsBooked++;

                                    var putTask = client.PutAsJsonAsync<RoomModel>("rooms/DeluxeTwoBedSuite", room);
                                    putTask.Wait();

                                    var putResult = putTask.Result;

                                    if (!putResult.IsSuccessStatusCode)
                                    {
                                        ModelState.AddModelError(string.Empty, "Unable to update the API");
                                    }
                                }
                            }
                            else if (booking.RoyalSuite > 0
                             && room.RoomType == RoomType.RoyalSuit.ToString()
                             && room.RoomsAvailable >= booking.RoyalSuite)
                            {
                                for (int i = 0; i < booking.RoyalSuite; i++)
                                {
                                    var royalSuite = new Room();

                                    royalSuite.IsAvailable = true;
                                    royalSuite.LastModifiedDate = DateTime.Now;
                                    royalSuite.RoomsSelected = booking.RoyalSuite;
                                    royalSuite.RoomTariff = room.RoomTariff;
                                    royalSuite.RoomType = room.RoomType;
                                    royalSuite.TotalNumberOfRoomsAvailable = room.RoomsAvailable;

                                    booking.Room.Add(royalSuite);

                                    room.RoomsAvailable--;
                                    room.RoomsBooked++;

                                    var putTask = client.PutAsJsonAsync<RoomModel>("rooms/RoyalSuite", room);
                                    putTask.Wait();

                                    var putResult = putTask.Result;

                                    if (!putResult.IsSuccessStatusCode)
                                    {
                                        ModelState.AddModelError(string.Empty, "Unable to update the API");
                                    }
                                }
                            }
                            else if (booking.KingSuite > 0
                             && room.RoomType == RoomType.KingSuit.ToString()
                             && room.RoomsAvailable >= booking.KingSuite)
                            {
                                for (int i = 0; i < booking.KingSuite; i++)
                                {
                                    var kingSuite = new Room();

                                    kingSuite.IsAvailable = true;
                                    kingSuite.LastModifiedDate = DateTime.Now;
                                    kingSuite.RoomsSelected = booking.KingSuite;
                                    kingSuite.RoomTariff = room.RoomTariff;
                                    kingSuite.RoomType = room.RoomType;
                                    kingSuite.TotalNumberOfRoomsAvailable = room.RoomsAvailable;

                                    booking.Room.Add(kingSuite);

                                    room.RoomsAvailable--;
                                    room.RoomsBooked++;

                                    var putTask = client.PutAsJsonAsync<RoomModel>("rooms/KingSuite", room);
                                    putTask.Wait();

                                    var putResult = putTask.Result;

                                    if (!putResult.IsSuccessStatusCode)
                                    {
                                        ModelState.AddModelError(string.Empty, "Unable to update the API");
                                    }
                                }
                            }
                        }
                    }


                    //Calculate the total cost

                    foreach (Room room in booking.Room)
                    {
                        totalTariffAmountPerDay += room.RoomTariff;
                    }

                    totalNumberOfDays = booking.CheckoutDate.Value.Day - booking.CheckinDate.Value.Day;
                    booking.TotalCost = totalTariffAmountPerDay * totalNumberOfDays;

                    //Remaining Room Details
                    booking.BookingDate = DateTime.Today;
                    booking.LastModifiedDate = DateTime.Today;

                    //Fill the person details
                    booking.Customer.Person.FirstName = booking.Customer.FirstName;
                    booking.Customer.Person.LastName = booking.Customer.LastName;

                    //Fill the payment details
                    booking.Payment = new Payment();
                    booking.Payment.CreditCardNumber = "XXXX XXXX XXXX XXXX";
                    booking.Payment.CVV = 888;
                    booking.Payment.ExpirationDate = DateTime.Today;
                    booking.Payment.NameOnCard = "Dummy Dummy";

                    //Fill the Employee Details(This employee is like a system admin)
                    booking.Employee = new Employee();
                    booking.Employee.Department = new Department();
                    booking.Employee.Department.DepartmentName = "Staff";
                    booking.Employee.EmployeeCode = "XACA1234";
                    booking.Employee.FirstName = "John";
                    booking.Employee.LastName = "Doe";
                    booking.Employee.Person = new Person();
                    booking.Employee.Person.FirstName = booking.Employee.FirstName;
                    booking.Employee.Person.LastName = booking.Employee.LastName;
                    booking.Employee.Person.Address = new Address();
                    booking.Employee.Person.Address.AddressLine1 = "Dummy Line 1";
                    booking.Employee.Person.Address.AddressLine1 = "Dummy Line 2";
                    booking.Employee.Person.Address.AddressType = "Office";
                    booking.Employee.Person.Address.City = "Newark";
                    booking.Employee.Person.Address.State = "New Jersey";
                    booking.Employee.Person.Address.Country = "United States";

                    //Generate a booking ID 
                    booking.BookingID = HelperMethods.HelperMethods.RandomString(10);
                    booking.BookingDate = DateTime.Today;


                }

                //Save the booking details into the table
                _context.Booking.AddAsync(booking);
                _context.SaveChangesAsync();

            }

            return View("Confirmation", booking);
        }

        //public IActionResult Confirmation

        //[Authorize]
        //[HttpPost]
        //public IActionResult SaveBookingDates(ReservationModel reservationModel)
        //{
        //    return View("Reservation", reservationModel);
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult SaveRoomDetails(ReservationModel reservationModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        reservationModel.RoomDetails = new List<RoomModel>();
        //        reservationModel.CustomerDetails = new CustomerModel();
        //        reservationModel.CustomerDetails.Address = new AddressModel();
        //        if (reservationModel.IsSingleRoom == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.SingleRoom, (double)RoomTariff.SingleRoom,
        //                true, (int)RoomsAvailable.SingleRoom);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsDoubleRoom == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.DoubleRoom, (double)RoomTariff.DoubleRoom,
        //                true, (int)RoomsAvailable.DoubleRoom);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsDeluxeOneBedroom == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.DeluxeOneBedroomSuite, 
        //                (double)RoomTariff.DeluxeOneBedroomSuite,
        //                true, (int)RoomsAvailable.DeluxeOneBedroomSuite);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsDeluxeTwoBedroom == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.DeluxeTwoBedroomSuite, 
        //                (double)RoomTariff.DeluxeTwoBedroomSuite,
        //                true, (int)RoomsAvailable.DeluxeTwoBedroomSuite);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsRoyalSuit == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.RoyalSuit, (double)RoomTariff.RoyalSuit,
        //                true, (int)RoomsAvailable.RoyalSuit);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsKingSuit == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.KingSuit, (double)RoomTariff.KingSuit,
        //                true, (int)RoomsAvailable.KingSuit);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }

        //        if (reservationModel != null && reservationModel.RoomDetails != null &&
        //        reservationModel.RoomDetails.Count > 0)
        //        {
        //            double totalCostofBooking = 0.0;

        //            foreach (var room in reservationModel.RoomDetails)
        //            {
        //                totalCostofBooking += (double)room.RoomTariff;
        //            }

        //            reservationModel.TotalCost = totalCostofBooking;
        //        }

        //    }

        //    return View("Reservation", reservationModel);
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult SubmitCustomerData(ReservationModel reservationModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Generate a booking ID 
        //        reservationModel.BookingID = HelperMethods.HelperMethods.RandomString(10);
        //    }

        //    HttpContext.Session.SetObjectAsJson("ReservationModel", reservationModel);
        //    return View("Reservation", reservationModel);
        //}

        [Authorize]
        [HttpGet]
        public IActionResult CustomerHistory()
        {
            var reservationModel = HttpContext.Session.GetObjectFromJson<Booking>("ReservationModel");

            return View("CustomerHistory", reservationModel);
        }

        public IActionResult Rooms()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult CustomerReviews()
        {
            ViewData["Message"] = "Customer Reviews Page";

            return View();
        }
    }
}
