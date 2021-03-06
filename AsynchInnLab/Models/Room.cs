﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchInnLab.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }

        //Navigation Properties

        ICollection<HotelRoom> HotelRoom { get; set; }
        public List<RoomAmenity> RoomAmenities { get; set; }
    }
}
