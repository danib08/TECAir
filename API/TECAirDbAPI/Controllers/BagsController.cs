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

    public class BagsController : ControllerBase
    {
        private readonly TECAirDbContext _context;

        public BagsController(TECAirDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Multi value get of bags
        /// </summary>
        /// <returns>All bags in database</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bag>>> GetBags()
        {
            return await _context.Bags.ToListAsync();
        }

        /// <summary>
        /// Single value get
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Required bag</returns>
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Bag>> GetBag(string id)
        {
            var bag = await _context.Bags.FindAsync(id);

            if (bag == null)
            {
                return NotFound();
            }

            return bag;
        }

        /// <summary>
        /// Put method to edit bags
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bag"></param>
        /// <returns>State of query</returns>
        
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBag(string id, Bag bag)
        {
            if (id != bag.Bagid)
            {
                return BadRequest();
            }

            _context.Entry(bag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagExists(id))
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
        /// Method to create a single Bag
        /// </summary>
        /// <param name="bag"></param>
        /// <returns></returns> 

        [HttpPost ("Bag")]
        public async Task<ActionResult<Bag>> PostBag(Bag bag)
        {
            _context.Bags.Add(bag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BagExists(bag.Bagid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBag", new { id = bag.Bagid }, bag);
        }

        /// <summary>
        /// Method to create bags
        /// </summary>
        /// <param name="bag"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult> PostBags(List<Bag> bagList)
        {

            while(bagList.Count() > 0)
            {
                _context.Bags.Add(bagList.First());

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (BagExists(bagList.First().Bagid))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                bagList.RemoveAt(0);
            }

            return Ok();
        }



        /// <summary>
        /// Method for deleting bags by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>State of task</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBag(string id)
        {
            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                return NotFound();
            }

            _context.Bags.Remove(bag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BagExists(string id)
        {
            return _context.Bags.Any(e => e.Bagid == id);
        }
    }
}
