using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Data;
using TECAirAPI.Models;
 
/// <summary>
/// Repository implementing Data context and interface methods
/// </summary>

namespace TECAirAPI.Repositories
{
  public class WorkerRepository : IWorkerRepository //Implementing the bag repository methods
  {
    private readonly IDataContext _context; //Definition of context from data context
    public WorkerRepository(IDataContext context)
    {
      _context = context;
 
    }

    /// <summary>
    /// Method Post to create Workers
    /// </summary>
    /// <param name="worker"></param>
    /// <returns></returns>

    public async Task Add(Worker worker)
    {        
      _context.Workers.Add(worker); //Adds a worker in the database
      await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method Delete to eliminate Workers from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Workers.FindAsync(id);  //Finds the object by its ID
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Workers.Remove(itemToRemove); //Remove object idetnified by itemToRemove
        await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method to GET  a specific Worker
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The desire Worker object accessed by its ID</returns>
    public async Task<Worker> Get(int id)
    {
        return await _context.Workers.FindAsync(id); //Finds the object by its ID
    }
 
    /// <summary>
    /// Method to GET all Workers
    /// </summary>
    /// <returns>All the Workers in the database</returns>

    public async Task<IEnumerable<Worker>> GetAll()
    {
        return await _context.Workers.ToListAsync(); //Converts to a list all items from data context
    }

    /// <summary>
    /// Method to Update a Worker
    /// </summary>
    /// <param name="worker"></param>
    /// <returns></returns>
 
    public async Task Update(Worker worker)
    {
        var itemToUpdate = await _context.Workers.FindAsync(worker.WorkerID); //Finds the Worker by its ID
        if (itemToUpdate == null)
            throw new NullReferenceException();
        itemToUpdate.WorkerID = worker.WorkerID; //Updates the Worker ID
        itemToUpdate.NameWorker = worker.NameWorker; //Updates the Worker's Name
        itemToUpdate.LastNameWorker = worker.LastNameWorker; //Updates the Worker's Last Name
        itemToUpdate.PassWorker = worker.PassWorker; //Updates the Worker's Password
        await _context.SaveChangesAsync(); //Save changes
 
    }
  }
}