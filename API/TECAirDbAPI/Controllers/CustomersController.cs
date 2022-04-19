using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TECAirDbAPI.Models;

namespace TECAirDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Customer Controller generated from DbContext
    public class CustomersController : ControllerBase
    {
        private readonly TECAirDbContext _context;

        public CustomersController(TECAirDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Multi value get of customers
        /// </summary>
        /// <returns>All customers in database</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        /// <summary>
        /// Single value get customer 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Required customer</returns>
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        /// <summary>
        /// Put method to edit customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns>State of query</returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Customerid)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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
        /// Method to create customers
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.Customerid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomer", new { id = customer.Customerid }, customer);
        }

        

        /*
        /// <summary>
        /// Single value get customer 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Required customer</returns>

        [HttpPost("validate")]
        public async Task<ActionResult<string>> CustomerValidation(Customer customer)
        {
            

            if (CustomerExists(customer.Customerid) && NameCustomer(customer.Namecustomer) && LastNameCustomer(customer.Lastnamecustomer))
            {
                var data = new JObject(new JProperty("Existe", "Si"));
                return data.ToString();
            }
            else
            {
                var data = new JObject(new JProperty("Existe", "No"));
                return data.ToString();
            }

        }

        */

        /// <summary>
        /// Method for deleting customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>State of task</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Customerid == id);
        }

        private bool NameCustomer(string name)
        {
            return _context.Customers.Any(e => e.Namecustomer.Equals(name));
        }

        private bool LastNameCustomer(string lastName)
        {
            return _context.Customers.Any(e => e.Lastnamecustomer.Equals(lastName));
        }
    }
}
