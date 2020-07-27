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
        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int roomNumber, int hotelId)
        {
            var hotelRoom = await GetAHotelRoom(roomNumber, hotelId);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
        }

        public async Task<HotelRoom> GetAHotelRoom(int roomNumber, int hotelId)
        {
            var hotelRoom = await _context.HotelRoom.FindAsync(roomNumber, hotelId);

            var room = _context.HotelRoom.Where(x => x.HotelId == hotelId && x.RoomNumber == roomNumber).Include(x => x.Room).SingleAsync();
            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int hotelId)
        {
            List<HotelRoom> hotelRooms = await _context.HotelRoom.Where(x => x.HotelId == hotelId).ToListAsync();
            return hotelRooms;
        }

        public async Task Update(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
