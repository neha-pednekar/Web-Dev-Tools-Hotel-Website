using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelViewModels
{
    public class CustomerHistory
    {
        public string CustomerHistoryID { get; set; }

        public Booking Booking { get; set; }
    }
}
