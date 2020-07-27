using AsynchInnLab.Data;
using AsynchInnLab.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AsynchInnLab.Models.Services 
{
    public class HotelRoomRepository : IHotelRoom
    {
        private AsynchInDbContext _context;
        public HotelRoomRepository(AsynchInDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// this creates a Hotelroom and adds it to database
        /// </summary>
        /// <param name="amenity">the specific Hotelroom to add</param>
        /// <returns>a new Hotelroom</returns>
        public async Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId)
        {
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
        /// <summary>
        /// this deletes a Hotelroom from the database
        /// </summary>
        /// <param name="id">the specific Hotelroom to delete</param>
        /// <returns>when all Hotelrooms are searched, this one does not show up anymore</returns>
        public async Task Delete(int roomNumber, int hotelId)
        {
            var hotelRoom = await GetAHotelRoom(roomNumber, hotelId);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
        }
        /// <summary>
        /// finds a specific Hotelroom using its id number
        /// </summary>
        /// <param name="id">the id number associated with the Hotelroom</param>
        /// <returns>the Hotelroom in question</returns>
        public async Task<HotelRoom> GetAHotelRoom(int roomNumber, int hotelId)
        {
            //var hotelRoom = await _context.HotelRoom.FindAsync(roomNumber, hotelId);

            var room = await _context.HotelRoom.Where(x => x.HotelId == hotelId && x.RoomNumber == roomNumber)
                .Include(x => x.Room)
                .ThenInclude(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .Include(x => x.Hotel)
                .FirstOrDefaultAsync();
            return room;
        }
        /// <summary>
        /// presents a list of all Hotelrooms
        /// </summary>
        /// <returns>the full list of Hotelrooms</returns>
        public async Task<List<HotelRoom>> GetHotelRooms(int hotelId)
        {
            List<HotelRoom> hotelRooms = await _context.HotelRoom.Where(x => x.HotelId == hotelId).ToListAsync();
            return hotelRooms;
        }
        /// <summary>
        /// updates the characteristics of an existing Hotelroom
        /// </summary>
        /// <param name="amenity">the Hotelroom to update</param>
        /// <returns>the updated Hotelroom</returns>
        public async Task Update(int hotelId, int roomNumber, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
