using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public RoomAmenities RoomAmenities { get; set; }
    }
}
