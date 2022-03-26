using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Data;
using TECAirAPI.Models;
 
namespace TECAirAPI.Repositories
{
  public class WorkerRepository : IWorkerRepository
  {
    private readonly IDataContext _context;
    public WorkerRepository(IDataContext context)
    {
      _context = context;
 
    }
    public async Task Add(Worker worker)
    {        
      _context.Workers.Add(worker);
      await _context.SaveChangesAsync();
    }
 
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Workers.FindAsync(id);
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Workers.Remove(itemToRemove);
        await _context.SaveChangesAsync();
    }
 
    public async Task<Worker> Get(int id)
    {
        return await _context.Workers.FindAsync(id);
    }
 
    public async Task<IEnumerable<Worker>> GetAll()
    {
        return await _context.Workers.ToListAsync();
    }
 
    public async Task Update(Worker worker)
    {
        var itemToUpdate = await _context.Workers.FindAsync(worker.WorkerID);
        if (itemToUpdate == null)
            throw new NullReferenceException();
        itemToUpdate.WorkerID = worker.WorkerID;
        itemToUpdate.NameWorker = worker.NameWorker;
        itemToUpdate.LastNameWorker = worker.LastNameWorker;
        itemToUpdate.PassWorker = worker.PassWorker;
        await _context.SaveChangesAsync();
 
    }
  }
}