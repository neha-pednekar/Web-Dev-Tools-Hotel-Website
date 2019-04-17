using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectNehaPalace.Models.HotelViewModels;

namespace ProjectNehaPalace.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext (DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectNehaPalace.Models.HotelViewModels.Booking> Booking { get; set; }
    }
}
