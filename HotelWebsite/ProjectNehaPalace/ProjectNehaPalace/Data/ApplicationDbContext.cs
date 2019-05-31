using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectNehaPalace.Models;
using ProjectNehaPalace.Models.HotelModels;

namespace ProjectNehaPalace.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<PhotoGallery> PhotoGallery { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<EmployeeCompensation> EmployeeCompensation { get; set; }
        public DbSet<CustomerReview> CustomerReviews { get; set; }
        public DbSet<NPInfo> NPInfo { get; set; }
        public DbSet<CustomerHistory> CustomerHistory { get; set; }
        public DbSet<PreBookingInformation> PreBookingInfo { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Address>().ToTable("Address");
            builder.Entity<Person>().ToTable("Person");
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Employee>().ToTable("Employee");
            builder.Entity<Department>().ToTable("Department");
            builder.Entity<Room>().ToTable("Room");
            builder.Entity<PhotoGallery>().ToTable("PhotoGallery");
            builder.Entity<Booking>().ToTable("Booking");
            builder.Entity<Payment>().ToTable("Payment");
            builder.Entity<EmployeeCompensation>().ToTable("EmployeeCompensation");
            builder.Entity<CustomerReview>().ToTable("CustomerReviews");
            builder.Entity<CustomerHistory>().ToTable("CustomerHistory");
            builder.Entity<NPInfo>().ToTable("NPInfo");
            builder.Entity<PreBookingInformation>().ToTable("PreBookingInfo");

        }
    }
}
