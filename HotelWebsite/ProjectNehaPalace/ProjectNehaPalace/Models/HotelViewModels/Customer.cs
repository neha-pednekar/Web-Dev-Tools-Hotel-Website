using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelViewModels
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [DisplayName("First Name: ")]
        public string FirstName { get; set; }

        [DisplayName("Last Name: ")]
        public string LastName { get; set; }

        public Address Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        //public ReservationModel ReservationInfo { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string SSN{ get; set; }
    }
}
