using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class NPInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string NPInfoID { get; set; }
    }
}
