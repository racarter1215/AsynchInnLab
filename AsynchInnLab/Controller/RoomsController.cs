﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsynchInnLab.Data;
using AsynchInnLab.Models;
using AsynchInnLab.Models.Interfaces;
using AsynchInnLab.Models.DTO;

namespace AsynchInnLab.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return await _room.GetRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            RoomDTO room = await _room.GetRoom(id);
            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            var updatedRoom = await _room.Update(room);
            return Ok(updatedRoom);

        }
        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
            
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {
            await _room.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        //POST: api/Room/{roomId}/{amenityId}
        //Model Binding
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenity(roomId, amenityId);
            return Ok();
        }

        [HttpDelete]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmenityFromRoom(roomId, amenityId);
            return Ok();
        }
        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
                await _room.Delete(id);
                return NoContent();                
        }
        

    }
}
