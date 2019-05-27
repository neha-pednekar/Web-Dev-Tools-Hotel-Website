using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelViewModels
{
    public class EmployeeCompensation
    {
        public string EmployeeCompensationID { get; set; }

        public Employee Employee { get; set; }

        public double Salary { get; set; }

        public double Bonus { get; set; }
    }
}
