﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models
{
    public class RoomAmenity
    {
        public int AmenityId { get; set; }
        public int RoomId { get; set; }

        //Navigation Properties
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
