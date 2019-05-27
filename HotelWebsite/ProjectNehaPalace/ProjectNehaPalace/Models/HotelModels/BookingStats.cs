using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelViewModels
{
    public class BookingStats
    {
        BookingManager reservationManager = new BookingManager();

        public async Task<int> GetBookingCount()
        {
            return await Task.FromResult(reservationManager.GetAllReservationBookings.Count());
        }

        public async Task<int> GetReservationsByCheckinDate(DateTime _checkinDate)
        {
            return await Task.FromResult(reservationManager.GetReservationsByCheckinDate(_checkinDate).Count);
        }
    }
}
