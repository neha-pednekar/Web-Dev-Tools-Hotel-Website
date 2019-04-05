using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelViewModels
{
    public class CustomerReview
    {
        public string CustomerReviewID { get; set; }

        public Customer Customer { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

    }
}
