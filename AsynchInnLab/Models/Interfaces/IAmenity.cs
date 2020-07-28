using AsynchInnLab.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models.Interfaces
{
    public interface IAmenity
    {
        //contains methods and properties that are required for the classes to implement
        /// <summary>
        /// creates a new amenity in the database
        /// </summary>
        /// <param name="hotel">an Amenity</param>
        /// <returns>a new Amenity</returns>
        Task<AmenityDTO> Create(Amenity hotel);

        
        /// <summary>
        /// get all existing amenities in the database
        /// </summary>
        /// <returns>the full list of amenities</returns>
        Task<List<AmenityDTO>> GetAmenities();

        /// <summary>
        /// search for an amenity by id number
        /// </summary>
        /// <param name="id">the specific amenity associated with the id</param>
        /// <returns>the amenity in question</returns>
        Task<AmenityDTO> GetAmenity(int id);

        /// <summary>
        /// update an existing amenity
        /// </summary>
        /// <param name="hotel">the specific amenity to update</param>
        /// <returns>the updated amenity</returns>
        Task<Amenity> Update(Amenity hotel);

        /// <summary>
        /// deletes the specific amenity
        /// </summary>
        /// <param name="id">the amenity to be deleted's id</param>
        /// <returns>the list of amenities without the deleted one</returns>
        Task Delete(int id);
    }
}
