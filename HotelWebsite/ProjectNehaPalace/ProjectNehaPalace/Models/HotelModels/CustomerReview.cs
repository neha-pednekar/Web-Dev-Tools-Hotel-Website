using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class CustomerReview
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CustomerReviewID { get; set; }

        public Customer Customer { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

    }
}
