using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Data;
using TECAirAPI.Models;
 
namespace TECAirAPI.Repositories
{
  public class BagRepository : IBagRepository
  {
    private readonly IDataContext _context;
    public BagRepository(IDataContext context)
    {
      _context = context;
 
    }
    public async Task Add(Bag bag)
    {        
      _context.Bags.Add(bag);
      await _context.SaveChangesAsync();
    }
 
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Bags.FindAsync(id);
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Bags.Remove(itemToRemove);
        await _context.SaveChangesAsync();
    }
 
    public async Task<Bag> Get(int id)
    {
        return await _context.Bags.FindAsync(id);
    }
 
    public async Task<IEnumerable<Bag>> GetAll()
    {
        return await _context.Bags.ToListAsync();
    }
 
    public async Task Update(Bag bag)
    {
        var itemToUpdate = await _context.Bags.FindAsync(bag.BagID);
        if (itemToUpdate == null)
            throw new NullReferenceException();
        itemToUpdate.BagID = bag.BagID;
        itemToUpdate.Weight = bag.Weight;
        itemToUpdate.Color = bag.Color;
        itemToUpdate.WorkerID = bag.WorkerID;
        await _context.SaveChangesAsync();
 
    }
  }
}