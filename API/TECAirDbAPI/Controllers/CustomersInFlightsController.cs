using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  Newtonsoft.Json.Linq;
using TECAirDbAPI.Models;

namespace TECAirDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //CustomerInFlight Controller generated from DbContext
    public class CustomersInFlightsController : ControllerBase
    {
        private readonly TECAirDbContext _context;

        public CustomersInFlightsController(TECAirDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Multi value get of customers in flight
        /// </summary>
        /// <returns>All customers in flight in database</returns>
        /// 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInFlight>>> GetCustomerInFlights()
        {
            return await _context.CustomerInFlights.ToListAsync();
        }


        /// <summary>
        /// Single value get
        /// </summary>
        /// <param name="customerInFlight"></param>
        /// <returns>Required flight</returns>

        [HttpPost("NoSeats")]

        public async Task<ActionResult<IEnumerable<CustomerInFlight>>> GetNoSeatCustomer(CustomerInFlight customerInFlight)
        {
            List<CustomerInFlight> data = new List<CustomerInFlight>();
            var cif = await _context.CustomerInFlights.ToListAsync();



            while (cif.Count() > 0)
            {

                if (cif.First().Customerid == customerInFlight.Customerid && cif.First().Seatnum == 0)
                {

                    data.Add(cif.First());
                    cif.RemoveAt(0);

                }
                else
                {
                    cif.RemoveAt(0);
                }

            }

            return data;
        }

        /// <summary>
        /// Single value get customer in flight
        /// </summary>
        /// <param name="customerid"></param>
        /// <param name="flightid"></param>
        /// <returns>Required customer in flight</returns>
        /// 
        [HttpGet("{flightid}")]
        public async Task<ActionResult<IEnumerable<CustomerInFlight>>> GetCustomerInFlight(string flightid)
        {
            var customerInFlight = await _context.CustomerInFlights.Where(i => i.Flightid.Equals(flightid)).Select(i => new CustomerInFlight
            {
                Flightid = i.Flightid,
                Seatnum = i.Seatnum
            }).ToArrayAsync();

            if (flightid == null)
            {
                return NotFound();
            }

            return customerInFlight;
        }

        /// <summary>
        /// Put method to edit customer in flight
        /// </summary>
        /// <param name="flightid"></param>
        /// <param name="customerInFlight"></param>
        /// <returns>State of query</returns>

        [HttpPut("{customerid}/{flightid}")]
        public async Task<IActionResult> PutCustomerInFlight(int customerid, string flightid, CustomerInFlight customerInFlight)
        {
            // TODO: Check if seat is already taken 

            if (customerid != customerInFlight.Customerid || flightid != customerInFlight.Flightid)
            {
                return BadRequest();
            }

            _context.Entry(customerInFlight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInFlightExists(customerid, flightid))
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
        /// Method to create customer in flight
        /// </summary>
        /// <param name="customerInFlight"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<CustomerInFlight>> PostCustomerInFlight(CustomerInFlight customerInFlight)
        {
            var flight = await _context.Flights.FindAsync(customerInFlight.Flightid);
            _context.CustomerInFlights.Add(customerInFlight);
            flight.Userquantity += 1;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerInFlightExists(customerInFlight.Customerid, customerInFlight.Flightid))
                {
                    return Ok();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        /// <summary>
        /// Method for deleting customer by id
        /// </summary>
        /// <param name="customerid"></param>
        /// <param name="flightid"></param>
        /// <returns>State of task</returns>
        ///
        [HttpDelete("{customerid}/{flightid}")]
        public async Task<IActionResult> DeleteCustomerInFlight(int customerid, string flightid)
        {
            var customerInFlight = await _context.CustomerInFlights.FindAsync(customerid, flightid);
            if (customerInFlight == null)
            {
                return NotFound();
            }

            _context.CustomerInFlights.Remove(customerInFlight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerInFlightExists(int customerid, string flightid)
        {
            return _context.CustomerInFlights.Any(e => e.Customerid == customerid && e.Flightid == flightid);
        }
    }
}
