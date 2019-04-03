using ProjectNehaPalace.Models.HotelViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Addresses.Any())
            {
                return;   // DB has been seeded
            }

            var addresses = new Address[]
            {
            new Address{AddressId="1111", AddressType="Billing",AddressLine1="143 Park Drive",City="Boston",
                State ="Massachusetts", Country= "US", ZipCode = "02215"}
            };
            foreach (Address a in addresses)
            {
                context.Addresses.Add(a);
            }
            context.SaveChanges();

            var people = new Person[]
            {
            new Person{PersonID="2222", FirstName="Neha", LastName="Pednekar" }
            };
            foreach (Person p in people)
            {
                context.People.Add(p);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
            new Customer{CustomerID=1, FirstName="Neha", LastName = "Pednekar",
                Address =new Address{
                     AddressId="2222"
                },  EmailAddress="npednekar9@gmail.com",
                PhoneNumber = "8572102616", SSN = "111111111"  }
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
        }
    }
}
