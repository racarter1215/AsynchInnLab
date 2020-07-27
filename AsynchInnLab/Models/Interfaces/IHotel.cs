using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models.Interfaces
{
    
    public interface IHotel
    {
        //contains methods and properties that are required for the classes to implement
        /// <summary>
        /// creates a new hotel in the database
        /// </summary>
        /// <param name="hotel">a Hotel</param>
        /// <returns>a new Hotel</returns>
        Task<Hotel> Create(Hotel hotel);


        /// <summary>
        /// get all existing Hotels in the database
        /// </summary>
        /// <returns>the full list of Hotels</returns>
        Task<List<Hotel>> GetHotels();

        /// <summary>
        /// search for an Hotel by id number
        /// </summary>
        /// <param name="id">the specific Hotel associated with the id</param>
        /// <returns>the Hotel in question</returns>
        Task<Hotel> GetHotel(int id);

        /// <summary>
        /// update an existing Hotel
        /// </summary>
        /// <param name="hotel">the specific Hotel to update</param>
        /// <returns>the updated Hotel</returns>
        Task<Hotel> Update(Hotel hotel);

        /// <summary>
        /// deletes the specific Hotel
        /// </summary>
        /// <param name="id">the Hotel to be deleted's id</param>
        /// <returns>the list of Hotels without the deleted one</returns>
        Task Delete(int id);
    }
}
