using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TECAirDbAPI.Models;

namespace TECAirDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Bag Controller generated from DbContext
    public class PlanesController : ControllerBase
    {
        private readonly TECAirDbContext _context;

        public PlanesController(TECAirDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Multi value get of planes
        /// </summary>
        /// <returns>All planes in database</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plane>>> GetPlanes()
        {
            return await _context.Planes.ToListAsync();
        }

        /// <summary>
        /// Single value get
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Required plane</returns>
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Plane>> GetPlane(string id)
        {
            var plane = await _context.Planes.FindAsync(id);

            if (plane == null)
            {
                return NotFound();
            }

            return plane;
        }

        /// <summary>
        /// Put method to edit planes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="plane"></param>
        /// <returns>State of query</returns>
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlane(string id, Plane plane)
        {
            if (id != plane.Planeid)
            {
                return BadRequest();
            }

            _context.Entry(plane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Method to create plane
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<Plane>> PostPlane(Plane plane)
        {
            _context.Planes.Add(plane);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlaneExists(plane.Planeid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlane", new { id = plane.Planeid }, plane);
        }

        /// <summary>
        /// Method for deleting planes by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>State of task</returns>
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlane(string id)
        {
            var plane = await _context.Planes.FindAsync(id);
            if (plane == null)
            {
                return NotFound();
            }

            _context.Planes.Remove(plane);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaneExists(string id)
        {
            return _context.Planes.Any(e => e.Planeid == id);
        }
    }
}
