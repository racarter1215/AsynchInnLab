using AsynchInnLab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Data
{
    public class AsynchInDbContext : DbContext
    {
        public AsynchInDbContext(DbContextOptions<AsynchInDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this tells the db that the enrollments table has a combo compositie key of the amenitiesid and roomid
            //modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelId, x.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(x => new { x.AmenitiesId, x.RoomId });


            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Seattle Marriott Redmond",
                    StreetAddress = "7401 164th Ave NE",
                    City = "Redmond",
                    State = "Washington",
                    PhoneNumber = "+1 (425) 498-4000"
                },

                new Hotel
                {
                    Id = 2,
                    Name = "Sheraton Grand Seattle",
                    StreetAddress = "1400 6th Ave)",
                    City = "Seattle",
                    State = "Washington",
                    PhoneNumber = "+1 (206) 621-9000"
                },

                new Hotel
                {
                    Id = 3,
                    Name = "Watertown Hotel",
                    StreetAddress = "4242 Roosevelt Way NE",
                    City = "Seattle",
                    State = "Washington",
                    PhoneNumber = "+1 (206) 826-4242"
                });

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "Seattle Saloon",
                    Layout = "1 Bedroom"
                },

                new Room
                {
                    Id = 2,
                    Name = "Moose Lodge",
                    Layout = "2 Bedroom"
                },

                new Room
                {
                    Id = 3,
                    Name = "Seattle Saloon",
                    Layout = "1 Bedroom"
                });

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    Id = 1,
                    Name = "Treadmill"
                },
                
                new Amenity
                {
                    Id = 2,
                    Name = "Pool"
                },
                
                new Amenity
                {
                    Id = 3,
                    Name = "Computer Room"
                });
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenity { get; set; }
        //public DbSet<HotelRoom> HotelRoom { get; set; }
    }
}
