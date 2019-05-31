using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PersonID { get; set; }

        public Address Address { get; set; }

        public string AddressID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
