using ProjectNehaPalace.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class PreBookingInformation
    {
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
        [Range(1, 10)]
        public int NumberOfAdults { get; set; }

        [Required]
        [Range(1, 10)]
        [DisplayName("Number of Children")]
        public int NumberOfChildren { get; set; }

        [DisplayName("Number of Rooms")]
        public double NumberOfRooms { get; set; }
    }
}
