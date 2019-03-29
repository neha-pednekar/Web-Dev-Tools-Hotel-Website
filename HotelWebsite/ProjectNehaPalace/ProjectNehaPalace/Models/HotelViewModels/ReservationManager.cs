using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelViewModels
{
    public class ReservationManager
    {
        readonly List<ReservationModel> _reservations = new List<ReservationModel>()
        {
            new ReservationModel{ CheckinDate = DateTime.Now.AddDays(10),
                                  CheckoutDate =  DateTime.Now.AddDays(11),
                                  NumberOfAdults = 1,
                                  NumberOfChildren = 0,
                                  IsDoubleRoom = true,
                                  RoomDetails = new List<RoomModel>()
                                  {
                                      new RoomModel
                                      (RoomType.DoubleRoom.ToString(), (double)RoomTariff.DoubleRoom, true, 
                                          (int)RoomsAvailable.DoubleRoom)  
                                  },
                                  CustomerDetails = new CustomerModel
                                  {
                                      FirstName = "Neha",
                                      LastName = "Pednekar",
                                      EmailAddress = "npednekar9@gmail.com",
                                      PhoneNumber = "8888888888",
                                      Address = new AddressModel()
                                      {
                                          AddressLine1 = "abcd",
                                          AddressLine2 = "efgh",
                                          City = "Boston",
                                          State = "MA",
                                          ZipCode = "02215"

                                      }
                                  }

                                 },

            new ReservationModel{ CheckinDate = DateTime.Now.AddDays(20),
                                  CheckoutDate =  DateTime.Now.AddDays(25),
                                  NumberOfAdults = 2,
                                  NumberOfChildren = 0,
                                  IsRoyalSuit = true,
                                  RoomDetails = new List<RoomModel>()
                                  {
                                      new RoomModel
                                      (   RoomType.SingleRoom.ToString(), 
                                          (double)RoomTariff.SingleRoom, 
                                          true, 
                                          (int)RoomsAvailable.SingleRoom)
                                  },
                                  CustomerDetails = new CustomerModel
                                  {
                                      FirstName = "Sneha",
                                      LastName = "Kawitkar",
                                      EmailAddress = "sk@gmail.com",
                                      PhoneNumber = "7878787878",
                                      Address = new AddressModel()
                                      {
                                          AddressLine1 = "abcd",
                                          AddressLine2 = "efgh",
                                          City = "Boston",
                                          State = "MA",
                                          ZipCode = "02215"

                                      }
                                  }

                                 }
        };


        //Get all  the reservation bookings
        public IEnumerable<ReservationModel> GetAllReservationBookings
        {
            get
            {
                return _reservations;
            }
        }


        //Get the reservations by checkin dates
        public List<ReservationModel> GetReservationsByCheckinDate(DateTime _checkinDate)
        {
            return _reservations.Where(x => x.CheckinDate == _checkinDate).ToList();
        }

        //public IEnumerable<Student> GetAll
        //{ get { return _students; } }

        //public List<Student> GetStudentsByGPA(int gpa)
        //{
        //    return _students.Where(x => x.GPA == gpa).ToList();
        //}
    }
}
