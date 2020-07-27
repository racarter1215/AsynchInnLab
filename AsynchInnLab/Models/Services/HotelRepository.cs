using AsynchInnLab.Data;
using AsynchInnLab.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models.Services
{
    public class HotelRepository : IHotel
    {
        private AsynchInDbContext _context;
        public HotelRepository(AsynchInDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// this creates a Hotel and adds it to database
        /// </summary>
        /// <param name="amenity">the specific Hotel to add</param>
        /// <returns>a new Hotel</returns>
        public async Task<Hotel> Create(Hotel hotel)
        {
            // when I have a hotel, i want to add themto the database.
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return hotel;
            
        }
        /// <summary>
        /// this deletes a Hotel from the database
        /// </summary>
        /// <param name="id">the specific Hotel to delete</param>
        /// <returns>when all Hotels are searched, this one does not show up anymore</returns>
        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);

            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// finds a specific Hotel using its id number
        /// </summary>
        /// <param name="id">the id number associated with the Hotel</param>
        /// <returns>the Hotel in question</returns>
        public async Task<Hotel> GetHotel(int id)
        {
            //look in the database on the student table, where the id is equal to the id that was brought in as an argument
            Hotel hotel =  await _context.Hotels.FindAsync(id);
            return hotel;
        }
        /// <summary>
        /// presents a list of all Hotels
        /// </summary>
        /// <returns>the full list of Hotels</returns>
        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }
        /// <summary>
        /// updates the characteristics of an existing Hotel
        /// </summary>
        /// <param name="amenity">the Hotel to update</param>
        /// <returns>the updated Hotel</returns>
        public async Task<Hotel> Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
