using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models.Interfaces
{
    public interface IAmenity
    {
        //contains methods and properties that are required for the classes to implement

        //create
        Task<Amenity> Create(Amenity hotel);

        //read
        //get all
        Task<List<Amenity>> GetAmenities();

        //get individually (by id)
        Task<Amenity> GetAmenity(int id);

        //update
        Task<Amenity> Update(Amenity hotel);

        //delete
        Task Delete(int id);
    }
}
