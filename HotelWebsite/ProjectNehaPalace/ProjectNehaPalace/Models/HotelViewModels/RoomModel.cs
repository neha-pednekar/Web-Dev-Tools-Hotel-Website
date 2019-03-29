using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelViewModels
{
    public class RoomModel
    {
        public RoomModel(string roomType, double roomTariff, bool availability, 
            int roomsAvailable)
        {
            RoomType = roomType;
            RoomTariff = roomTariff;
            Availability = availability;
            RoomsAvailable = roomsAvailable;
        }

        [DisplayName("Room Type")]
        public string RoomType { get; set; }

        [DisplayName("Room Tariff")]
        public double RoomTariff { get; set; }

        [DisplayName("Availability")]
        public bool Availability { get; set; }

        [DisplayName("Number of Rooms Available")]
        public int RoomsAvailable { get; set; }

    }

    [Flags]
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

    public enum RoomTariff
    {
        SingleRoom = 240,
        DoubleRoom = 350,
        DeluxeOneBedroomSuite = 440,
        DeluxeTwoBedroomSuite = 480,
        RoyalSuit = 530,
        KingSuit = 620
    }

    public enum RoomsAvailable
    {
        SingleRoom = 20,
        DoubleRoom = 10,
        DeluxeOneBedroomSuite = 5,
        DeluxeTwoBedroomSuite = 5,
        RoyalSuit = 2,
        KingSuit = 2
    }

}
