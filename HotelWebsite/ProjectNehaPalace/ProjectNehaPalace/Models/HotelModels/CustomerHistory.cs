using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class CustomerHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CustomerHistoryID { get; set; }

        public Booking Booking { get; set; }
    }
}
