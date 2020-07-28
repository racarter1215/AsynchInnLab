using AsynchInnLab.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models.Interfaces
{
    public interface IRoom
    {
        //contains methods and properties that are required for the classes to implement
        /// <summary>
        /// creates a new Room in the database
        /// </summary>
        /// <param name="hotel">a Room</param>
        /// <returns>a new Room</returns>
        Task<RoomDTO> Create(RoomDTO room);

        /// <summary>
        /// get all existing Rooms in the database
        /// </summary>
        /// <returns>the full list of Rooms</returns>
        Task<List<RoomDTO>> GetRooms();

        /// <summary>
        /// search for an Room by id number
        /// </summary>
        /// <param name="id">the specific Room associated with the id</param>
        /// <returns>the Room in question</returns>
        Task<RoomDTO> GetRoom(int id);

        /// <summary>
        /// update an existing Room
        /// </summary>
        /// <param name="hotel">the specific Room to update</param>
        /// <returns>the updated Room</returns>
        Task<Room> Update(Room room);

        /// <summary>
        /// deletes the specific Room
        /// </summary>
        /// <param name="id">the Room to be deleted's id</param>
        /// <returns>the list of Rooms without the deleted one</returns>
        Task Delete(int id);

        Task AddAmenity(int amenityId, int roomId);
        /// <summary>
        /// removes an amenity from a romm
        /// </summary>
        /// <param name="roomId">the room in question</param>
        /// <param name="amenityId">the amenity to remove</param>
        /// <returns>the room in question without the amenity</returns>
        Task RemoveAmenityFromRoom(int roomId, int amenityId);
    }
}
