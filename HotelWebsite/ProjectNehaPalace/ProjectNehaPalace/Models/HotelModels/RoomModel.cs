namespace ProjectNehaPalace.Models.HotelModels
{
    public class RoomModel
    {
        public string Id { get; set; }

        public string RoomType { get; set; }

        public double RoomTariff { get; set; }

        public int RoomsAvailable { get; set; }

        public int RoomsBooked { get; set; }

        public int TotalRooms { get; set; }
    }
}
