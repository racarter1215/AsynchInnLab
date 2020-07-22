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
        public async Task<Amenity> Create(Amenity amenity)
        {
            // when I have a hotel, i want to add themto the database.
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return amenity;

        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);

            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            //look in the database on the student table, where the id is equal to the id that was brought in as an argument
            Amenity amenity = await _context.Amenities.FindAsync(id);
            return amenity;
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenity> Update(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
