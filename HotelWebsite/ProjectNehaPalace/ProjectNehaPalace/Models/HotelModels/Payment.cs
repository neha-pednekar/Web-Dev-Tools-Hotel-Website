using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models.HotelModels
{
    public class Payment
    {
        public string PaymentID { get; set; }

        public string NameOnCard { get; set; }

        public string CreditCardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int CVV { get; set; }
    }
}
