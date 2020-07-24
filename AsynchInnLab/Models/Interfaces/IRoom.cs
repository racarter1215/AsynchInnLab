using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models.Interfaces
{
    public interface IRoom
    {
        //contains methods and properties that are required for the classes to implement

        //create
        Task<Room> Create(Room room);

        //read
        //get all
        Task<List<Room>> GetRooms();

        //get individually (by id)
        Task<Room> GetRoom(int id);

        //update
        Task<Room> Update(Room room);

        //delete
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
