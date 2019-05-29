using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Newtonsoft.Json;
using ProjectNehaPalace.HelperMethods;
using ProjectNehaPalace.Models.HotelModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectNehaPalace.Controllers
{
    public class HotelController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:51947/";
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
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Reservation(PreBookingInformation preBookingInformation)
        {
            var booking = new Booking();
            if (ModelState.IsValid)
            {
                booking.CheckinDate = preBookingInformation.CheckinDate;
                booking.CheckoutDate = preBookingInformation.CheckoutDate;
                booking.NumberOfAdults = preBookingInformation.NumberOfAdults;
                booking.NumberOfChildren = preBookingInformation.NumberOfChildren;
                booking.NumberOfRooms = preBookingInformation.NumberOfRooms;
            }
            
            return View("Reservation", booking);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SaveBookingDates(Booking booking)
        {
            return View("Reservation", booking);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveRoomDetailsAsync(Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.Room = new List<Room>();

                //First check the availability of the room from the API
                List<RoomModel> RoomsList = new List<RoomModel>();

                //using (var client = new HttpClient())
                //{
                //    //Passing service base url  
                //    client.BaseAddress = new Uri(Baseurl);

                //    client.DefaultRequestHeaders.Clear();
                //    //Define request data format  
                //    client.DefaultRequestHeaders.Accept.Add
                //        (new MediaTypeWithQualityHeaderValue("application/json"));

                //    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                //    HttpResponseMessage Res = await client.GetAsync("api/rooms/");

                //    //Checking the response is successful or not which is sent using HttpClient  
                //    if (Res.IsSuccessStatusCode)
                //    {
                //        //Storing the response details recieved from web api   
                //        var RoomsResponse = Res.Content.ReadAsStringAsync().Result;

                //        //Deserializing the response recieved from web api and storing into the Employee list  
                //        RoomsList = JsonConvert.DeserializeObject<List<RoomModel>>(RoomsResponse);

                //    }
                //}
                    
            

            //If the rooms are available then go ahead with the booking
            //if(RoomsList != null && RoomsList.Count > 0)
            //    {
            //       foreach(RoomModel room in RoomsList)
            //        {
            //            if(booking.SingleRoom > 0
            //             && room.RoomType == RoomType.SingleRoom.ToString() 
            //             && room.RoomsAvailable >= booking.SingleRoom)
            //            {
            //                var singleRoom = new Room();
            //                singleRoom.IsAvailable = true;
            //                singleRoom.LastModifiedDate = DateTime.Now;
            //                singleRoom.RoomsSelected = booking.SingleRoom;
            //                singleRoom.RoomTariff = room.RoomTariff;
            //                singleRoom.RoomType = room.RoomType;
            //                singleRoom.TotalNumberOfRoomsAvailable = room.RoomsAvailable;
            //                booking.Room.Add(singleRoom);
            //            }
            //            else
            //            {

            //            }
            //        }
            //    }

            //Calculate the total cost



            //reservationModel.Room

            //reservationModel.RoomDetails = new List<Room>();
            //reservationModel.CustomerDetails = new Customer();
            //reservationModel.CustomerDetails.Address = new Address();
            //if (reservationModel.IsSingleRoom == true)
            //{
            //    var roomModel = new Room(RoomType.SingleRoom.ToString(), (double)RoomTariff.SingleRoom,
            //        true, (int)RoomsAvailable.SingleRoom);
            //    reservationModel.RoomDetails.Add(roomModel);
            //}
            //if (reservationModel.IsDoubleRoom == true)
            //{
            //    var roomModel = new Room(RoomType.DoubleRoom.ToString(), (double)RoomTariff.DoubleRoom,
            //        true, (int)RoomsAvailable.DoubleRoom);
            //    reservationModel.RoomDetails.Add(roomModel);
            //}
            //if (reservationModel.IsDeluxeOneBedroom == true)
            //{
            //    var roomModel = new Room(RoomType.DeluxeOneBedroomSuite.ToString(),
            //        (double)RoomTariff.DeluxeOneBedroomSuite,
            //        true, (int)RoomsAvailable.DeluxeOneBedroomSuite);
            //    reservationModel.RoomDetails.Add(roomModel);
            //}
            //if (reservationModel.IsDeluxeTwoBedroom == true)
            //{
            //    var roomModel = new Room(RoomType.DeluxeTwoBedroomSuite.ToString(),
            //        (double)RoomTariff.DeluxeTwoBedroomSuite,
            //        true, (int)RoomsAvailable.DeluxeTwoBedroomSuite);
            //    reservationModel.RoomDetails.Add(roomModel);
            //}
            //if (reservationModel.IsRoyalSuit == true)
            //{
            //    var roomModel = new Room(RoomType.RoyalSuit.ToString(), (double)RoomTariff.RoyalSuit,
            //        true, (int)RoomsAvailable.RoyalSuit);
            //    reservationModel.RoomDetails.Add(roomModel);
            //}
            //if (reservationModel.IsKingSuit == true)
            //{
            //    var roomModel = new Room(RoomType.KingSuit.ToString(), (double)RoomTariff.KingSuit,
            //        true, (int)RoomsAvailable.KingSuit);
            //    reservationModel.RoomDetails.Add(roomModel);
            //}

            //int daysOfStay = (reservationModel.CheckoutDate - reservationModel.CheckinDate).Days;
            //reservationModel.NumberOfDays = daysOfStay;

            //if (reservationModel != null && reservationModel.RoomDetails != null &&
            //reservationModel.RoomDetails.Count > 0)
            //{
            //    double totalCostofBooking = 0.0;

            //    foreach (var room in reservationModel.RoomDetails)
            //    {
            //        totalCostofBooking += (double)room.RoomTariff;
            //    }

            //    //Multiply the booking cost with number of days
            //    totalCostofBooking = totalCostofBooking * daysOfStay;

            //    reservationModel.TotalCost = totalCostofBooking;
            //}

        }

            return View("Reservation", booking);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SubmitCustomerData(Booking reservationModel)
        {
            if (ModelState.IsValid)
            {
                //reservationModel.RoomDetails = new List<Room>();
                //if (reservationModel.IsSingleRoom == true)
                //{
                //    var roomModel = new Room(RoomType.SingleRoom.ToString(), (double)RoomTariff.SingleRoom,
                //        true, (int)RoomsAvailable.SingleRoom);
                //    reservationModel.RoomDetails.Add(roomModel);
                //}
                //if (reservationModel.IsDoubleRoom == true)
                //{
                //    var roomModel = new Room(RoomType.DoubleRoom.ToString(), (double)RoomTariff.DoubleRoom,
                //        true, (int)RoomsAvailable.DoubleRoom);
                //    reservationModel.RoomDetails.Add(roomModel);
                //}
                //if (reservationModel.IsDeluxeOneBedroom == true)
                //{
                //    var roomModel = new Room(RoomType.DeluxeOneBedroomSuite.ToString(),
                //        (double)RoomTariff.DeluxeOneBedroomSuite,
                //        true, (int)RoomsAvailable.DeluxeOneBedroomSuite);
                //    reservationModel.RoomDetails.Add(roomModel);
                //}
                //if (reservationModel.IsDeluxeTwoBedroom == true)
                //{
                //    var roomModel = new Room(RoomType.DeluxeTwoBedroomSuite.ToString(),
                //        (double)RoomTariff.DeluxeTwoBedroomSuite,
                //        true, (int)RoomsAvailable.DeluxeTwoBedroomSuite);
                //    reservationModel.RoomDetails.Add(roomModel);
                //}
                //if (reservationModel.IsRoyalSuit == true)
                //{
                //    var roomModel = new Room(RoomType.RoyalSuit.ToString(), (double)RoomTariff.RoyalSuit,
                //        true, (int)RoomsAvailable.RoyalSuit);
                //    reservationModel.RoomDetails.Add(roomModel);
                //}
                //if (reservationModel.IsKingSuit == true)
                //{
                //    var roomModel = new Room(RoomType.KingSuit.ToString(), (double)RoomTariff.KingSuit,
                //        true, (int)RoomsAvailable.KingSuit);
                //    reservationModel.RoomDetails.Add(roomModel);
                //}

                //Generate a booking ID 
                reservationModel.BookingID = HelperMethods.HelperMethods.RandomString(10);
                reservationModel.BookingDate = DateTime.Today;
            }

            //HttpContext.Session.SetObjectAsJson("ReservationModel", reservationModel);
            return View("Reservation", reservationModel);
        }

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
