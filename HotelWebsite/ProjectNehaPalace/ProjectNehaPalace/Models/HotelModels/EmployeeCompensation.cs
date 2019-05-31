using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class EmployeeCompensation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string EmployeeCompensationID { get; set; }

        public Employee Employee { get; set; }

        public double Salary { get; set; }

        public double Bonus { get; set; }
    }
}
