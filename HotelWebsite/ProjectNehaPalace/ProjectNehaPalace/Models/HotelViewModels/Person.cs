using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelViewModels
{
    public class Person
    {
        public string PersonID { get; set; }

        public Address Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
