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

    //Workers Controller generated from DbContext
    public class WorkersController : ControllerBase
    {
        private readonly TECAirDbContext _context;

        public WorkersController(TECAirDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Multi value get of workers
        /// </summary>
        /// <returns>All workers in database</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> GetWorkers()
        {
            return await _context.Workers.ToListAsync();
        }

        /// <summary>
        /// Single value get
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Required worker</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return worker;
        }

        [HttpPost("validate")]
        public string WorkerValidation(Worker worker)
        {
            if (WorkerExists(worker.Workerid) && NameWorker(worker.Nameworker) && LastNameWorker(worker.Lastnameworker))
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

        /// <summary>
        /// Put method to edit workers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="worker"></param>
        /// <returns>State of query</returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(int id, Worker worker)
        {
            if (id != worker.Workerid)
            {
                return BadRequest();
            }

            _context.Entry(worker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
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
        /// Method to create worker
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult> PostWorker(List<Worker> workerList)
        {
            while (workerList.Count() > 0)
            {
                _context.Workers.Add(workerList.First());

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (WorkerExists(workerList.First().Workerid))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
                workerList.RemoveAt(0);

            }

            return Ok();

        }
        

        /// <summary>
        /// Method for deleting workers by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>State of task</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.Workerid == id);
        }

        private bool NameWorker(string name)
        {
            return _context.Workers.Any(e => e.Nameworker.Equals(name));
        }

        private bool LastNameWorker(string lastName)
        {
            return _context.Workers.Any(e => e.Lastnameworker.Equals(lastName));
        }
    }
}
