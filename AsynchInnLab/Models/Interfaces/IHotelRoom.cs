using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId);
        Task Update(HotelRoom hotel);
        Task Delete(int roomNumber, int hotelId);
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        Task<HotelRoom> GetAHotelRoom(int roomNumber, int hotelId);
    }
}
