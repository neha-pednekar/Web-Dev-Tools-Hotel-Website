using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class PhotoGallery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PhotoGalleryID { get; set; }

        public string PhotoCategory { get; set; }

        public string PhotoURL { get; set; }
    }
}
