using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectNehaPalace.Models.HotelModels;

namespace ProjectNehaPalace.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext (DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectNehaPalace.Models.HotelModels.Customer> Customer { get; set; }
    }
}
