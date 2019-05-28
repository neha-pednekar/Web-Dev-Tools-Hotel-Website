using ProjectNehaPalace.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class Booking
    {
        [DisplayName("Booking ID")]
        public String BookingID { get; set; }

        public ICollection<Room> Room { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public Payment Payment { get; set; }

        [Required]
        [DisplayName("Checkin Date")]
        [ValidateDateRange(6)]
        [DataType(DataType.Date)]
        public DateTime CheckinDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Checkout Date")]
        [ValidateDateRange(6)]
        public DateTime CheckoutDate { get; set; }

        [Required]
        [DisplayName("Number of Adults")]
        public int NumberOfAdults { get; set; }

        [Required]
        [DisplayName("Number of Children")]
        public int NumberOfChildren { get; set; }

        [DisplayName("Total Cost")]
        public double TotalCost { get; set; }

        [DisplayName("Number of Rooms")]
        public double NumberOfRooms { get; set; }

        [DisplayName("Number of Days")]
        public int NumberOfDays { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
