using ProjectNehaPalace.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class PreBookingInformation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PreBookingInformationID { get; set; }

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

        //We are just using this information for our reference
        public string LoggedInUserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEntered { get; set; }
    }
}
