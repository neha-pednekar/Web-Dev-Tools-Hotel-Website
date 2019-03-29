using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models
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

        public string RoomType { get; set; }

        public double RoomTariff { get; set; }

        public bool Availability { get; set; }

        public int RoomsAvailable { get; set; }

    }

    public enum RoomType
    {
        [DisplayName("Single Room")]
        SingleRoom,
        [DisplayName("Double Room")]
        DoubleRoom,
        [DisplayName("Deluxe One Bedroom Suite")]
        DeluxeOneBedroomSuite,
        [DisplayName("Deluxe Two Bedroom Suite")]
        DeluxeTwoBedroomSuite,
        [DisplayName("Royal Suite")]
        RoyalSuit,
        [DisplayName("King Suite")]
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
