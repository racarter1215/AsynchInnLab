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
    public class RoomRepository : IRoom
    {
        private AsynchInDbContext _context;
        public RoomRepository(AsynchInDbContext context)
        {
            _context = context;
        }
        public async Task<Room> Create(Room room)
        {
            // when I have a hotel, i want to add themto the database.
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return room;

        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);

            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            //look in the database on the student table, where the id is equal to the id that was brought in as an argument
            Room room = await _context.Rooms.FindAsync(id);
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        /// <summary>
        /// add a room and an amenity together
        /// </summary>
        /// <param name="amenityId">a type of amenity</param>
        /// <param name="roomId">a particular room in the hotel</param>
        /// <returns>modified room with amenities</returns>
        public async Task AddAmenity(int amenityId, int roomId)
        {
            RoomAmenities roomAmenities = new RoomAmenities()
            {
                RoomId = roomId,
                AmenitiesId = amenityId
            };

            _context.Entry(roomAmenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
            
        }
        /// <summary>
        /// removes amenity from a room
        /// </summary>
        /// <param name="roomId">sets the room in question</param>
        /// <param name="amenityId">sets the amenity in question</param>
        /// <returns>room without given amenity</returns>
        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var result = _context.RoomAmenity.FirstOrDefault(x => x.RoomId == roomId && x.AmenitiesId == amenityId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
