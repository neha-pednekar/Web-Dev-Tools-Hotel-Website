using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CustomerID { get; set; }

        public Person Person { get; set; }

        public string PersonID { get; set; }

        [DisplayName("First Name: ")]
        public string FirstName { get; set; }

        [DisplayName("Last Name: ")]
        public string LastName { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        
    }
}
