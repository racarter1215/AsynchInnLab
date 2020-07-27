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
    public class AmenityRepository : IAmenity
    {
        private AsynchInDbContext _context;
        public AmenityRepository(AsynchInDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// this creates an Amenity and adds it to database
        /// </summary>
        /// <param name="amenity">the specific amenity to add</param>
        /// <returns>a new amenity</returns>
        public async Task<Amenity> Create(Amenity amenity)
        {
            // when I have a hotel, i want to add themto the database.
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return amenity;

        }
        /// <summary>
        /// this deletes an amenity from the database
        /// </summary>
        /// <param name="id">the specific amenity to delete</param>
        /// <returns>when all amenitys are searched, this one does not show up anymore</returns>
        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);

            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// finds a specific amenity using its id number
        /// </summary>
        /// <param name="id">the id number associated with the amenity</param>
        /// <returns>the amenity in question</returns>
        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            return amenity;
        }
        /// <summary>
        /// presents a list of all amenities
        /// </summary>
        /// <returns>the full list of amenities</returns>
        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }
        /// <summary>
        /// updates the characteristics of an existing amenity
        /// </summary>
        /// <param name="amenity">the amenity to update</param>
        /// <returns>the updated amenity</returns>
        public async Task<Amenity> Update(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
