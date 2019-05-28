using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class Room
    {
        //public Room(string roomType, double roomTariff, bool availability, 
        //    int roomsAvailable)
        //{
        //    RoomType = roomType;
        //    RoomTariff = roomTariff;
        //    IsAvailable = availability;
        //    Availability = roomsAvailable;
        //}
        
        public int RoomID { get; set; }

        public int RoomNumber { get; set; }

        [DisplayName("Room Type")]
        public string RoomType { get; set; }
        
        [DisplayName("Available?")]
        public bool IsAvailable { get; set; }

        [DisplayName("Number of Rooms Available")]
        public int Availability { get; set; }

        public int TotalNumberOfRooms { get; set; }

        public int RoomsOccupied { get; set; }

        [DisplayName("Room Tariff")]
        public double RoomTariff { get; set; }

        public DateTime LastModifiedDate { get; set; }


    }

    //[Flags]
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
