using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;

/// <summary>
/// Worker Controller with logic of its methods
/// </summary>

namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WorkersController : ControllerBase //Base Controller implementation
  {
    private readonly IWorkerRepository _workerRepository; //Worker Repository implementation
    public WorkersController(IWorkerRepository workerRepository)
    {
      _workerRepository = workerRepository;
    }
 
    /// <summary>
    /// Get method of all workers
    /// </summary>
    /// <returns>All Workers in database</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Worker>>> GetWorkers()
    {
        var workers = await _workerRepository.GetAll(); //Get all workers in database
        return Ok(workers); //Returns workers
    }
 
    /// <summary>
    /// Get method of a specific worker
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Required worker by ID</returns>

    [HttpGet("{id}")]
    public async Task<ActionResult<Worker>> GetWorker(int id)
    {
        var worker = await _workerRepository.Get(id); //Gets a worker by its ID
        if(worker == null)
            return NotFound();
 
        return Ok(worker); //Returns worker and acceptance
    }
 
    [HttpPost]
    public async Task<ActionResult> CreateWorker(CreateWorkerDto createWorkerDto)
    {
        Worker worker = new()
        {
            WorkerID = createWorkerDto.WorkerID,
            NameWorker = createWorkerDto.NameWorker,
            LastNameWorker = createWorkerDto.LastNameWorker,
            PassWorker = createWorkerDto.PassWorker,
        };
 
        await _workerRepository.Add(worker);
        return Ok();
    }
 
    /// <summary>
    /// Method to delete Workers by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Acceptance from Task</returns>

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteWorker(int id)
    {
        await _workerRepository.Delete(id); //Deletes worker by its ID
        return Ok(); //Returns acceptance
    }
 
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateWorker(int id, UpdateWorkerDto updateWorkerDto)
    {
        Worker worker = new()
        {
            WorkerID = updateWorkerDto.WorkerID,
            NameWorker = updateWorkerDto.NameWorker,
            LastNameWorker = updateWorkerDto.LastNameWorker,
            PassWorker = updateWorkerDto.PassWorker
        };
 
        await _workerRepository.Update(worker);
        return Ok();
    }
  }
}