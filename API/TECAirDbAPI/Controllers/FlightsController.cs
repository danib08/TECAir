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
    public class FlightsController : ControllerBase
    {
        private readonly TECAirDbContext _context;

        public FlightsController(TECAirDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Multi value get of flights
        /// </summary>
        /// <returns>All flights in database</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            return await _context.Flights.ToListAsync();
        }

        /// <summary>
        /// Single value get
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Required flight</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(string id)
        {
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        /// <summary>
        /// Put method to edit flights
        /// </summary>
        /// <param name="id"></param>
        /// <param name="flight"></param>
        /// <returns>State of query</returns>
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(string id, Flight flight)
        {
            if (id != flight.Flightid)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
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
        /// Method to create Flights
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns> 
        
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlightExists(flight.Flightid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlight", new { id = flight.Flightid }, flight);
        }

        /// <summary>
        /// Method for deleting flight by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>State of task</returns>
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(string id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(string id)
        {
            return _context.Flights.Any(e => e.Flightid == id);
        }
    }
}
