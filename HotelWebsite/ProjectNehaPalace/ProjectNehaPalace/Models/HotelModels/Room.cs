using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }

        public int RoomNumber { get; set; }

        [DisplayName("Room Type")]
        public string RoomType { get; set; }
        
        [DisplayName("Available?")]
        public bool IsAvailable { get; set; }

        [DisplayName("Number of Rooms Available")]
        public int TotalNumberOfRoomsAvailable { get; set; }

        public int RoomsSelected { get; set; }

        [DisplayName("Room Tariff")]
        public double RoomTariff { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }

    public enum RoomType
    {
        [Display(Name = "Single Room")]
        SingleRoom,
        [Display(Name = "Double Room")]
        DoubleRoom,
        [Display(Name = "Deluxe One Bedroom Room")]
        DeluxeOneBedroomSuite,
        [Display(Name = "Deluxe Two Bedroom Room")]
        DeluxeTwoBedroomSuite,
        [Display(Name = "Royal Suit")]
        RoyalSuit,
        [Display(Name = "King Suit")]
        KingSuit
    }

}
