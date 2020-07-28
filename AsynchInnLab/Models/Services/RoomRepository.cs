using AsynchInnLab.Data;
using AsynchInnLab.Models.DTO;
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
        /// <summary>
        /// this creates a Room and adds it to database
        /// </summary>
        /// <param name="amenity">the specific Room to add</param>
        /// <returns>a new Room</returns>
        public async Task<Room> Create(Room room)
        {
            // when I have a hotel, i want to add themto the database.
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return room;

        }
        /// <summary>
        /// this deletes a Room from the database
        /// </summary>
        /// <param name="id">the specific Room to delete</param>
        /// <returns>when all Rooms are searched, this one does not show up anymore</returns>
        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);

            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// finds a specific Room using its id number
        /// </summary>
        /// <param name="id">the id number associated with the Room</param>
        /// <returns>the Room in question</returns>
        public async Task<RoomDTO> GetRoom(int id)
        {      
            Room room = await _context.Rooms.FindAsync(id);
            RoomDTO dto = new RoomDTO()
            {
                Name = room.Name,
                ID = room.Id
            };
            return dto;
        }
        /// <summary>
        /// presents a list of all Rooms
        /// </summary>
        /// <returns>the full list of Rooms</returns>
        public async Task<List<RoomDTO>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            List<RoomDTO> dtos = new List<RoomDTO>();
            foreach (var item in rooms)
            {
                dtos.Add(new RoomDTO() { Name = item.Name, ID = item.Id, Layout = item.Layout });
            }
            return dtos;
        }
    
        /// <summary>
        /// updates the characteristics of an existing Room
        /// </summary>
        /// <param name="amenity">the Room to update</param>
        /// <returns>the updated Room</returns>
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
            RoomAmenity roomAmenities = new RoomAmenity()
            {
                RoomId = roomId,
                AmenityId = amenityId
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
            var result = _context.RoomAmenities.FirstOrDefault(x => x.RoomId == roomId && x.AmenityId == amenityId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
