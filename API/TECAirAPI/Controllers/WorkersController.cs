using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;
 
namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WorkersController : ControllerBase
  {
    private readonly IWorkerRepository _workerRepository;
    public WorkersController(IWorkerRepository workerRepository)
    {
      _workerRepository = workerRepository;
    }
 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Worker>>> GetWorkers()
    {
        var workers = await _workerRepository.GetAll();
        return Ok(workers);
    }
 
    [HttpGet("{id}")]
    public async Task<ActionResult<Worker>> GetWorker(int id)
    {
        var worker = await _workerRepository.Get(id);
        if(worker == null)
            return NotFound();
 
        return Ok(worker);
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
 
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteWorker(int id)
    {
        await _workerRepository.Delete(id);
        return Ok();
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