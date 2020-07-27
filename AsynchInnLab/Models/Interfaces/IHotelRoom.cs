using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models.Interfaces
{
    public interface IHotelRoom
    {
        //contains methods and properties that are required for the classes to implement
        /// <summary>
        /// creates a new hotelroom in the database
        /// </summary>
        /// <param name="hotel">a Hotelroom</param>
        /// <returns>a new Hotelroom</returns>
        /// 
        Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId);

        /// <summary>
        /// update an existing Hotelroom
        /// </summary>
        /// <param name="hotel">the specific Hotelroom to update</param>
        /// <returns>the updated Hotelroom</returns>

        Task Update(int hotelId, int roomNumber, HotelRoom hotelRoom);

        /// <summary>
        /// deletes the specific Hotelroom
        /// </summary>
        /// <param name="id">the Hotelroom to be deleted's id</param>
        /// <returns>the list of Hotelrooms without the deleted one</returns>

        Task Delete(int roomNumber, int hotelId);

        /// <summary>
        /// get all existing Hotelrooms in the database
        /// </summary>
        /// <returns>the full list of Hotelrooms</returns>
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);

        /// <summary>
        /// search for an Hotelroom by id number
        /// </summary>
        /// <param name="id">the specific Hotelroom associated with the id</param>
        /// <returns>the Hotelroom in question</returns>
        Task<HotelRoom> GetAHotelRoom(int roomNumber, int hotelId);
    }
}
