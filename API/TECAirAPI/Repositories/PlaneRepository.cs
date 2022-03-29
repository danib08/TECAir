using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Data;
using TECAirAPI.Models;
 
namespace TECAirAPI.Repositories
{
  public class PlaneRepository : IPlaneRepository
  {
    private readonly IDataContext _context;
    public PlaneRepository(IDataContext context)
    {
      _context = context;
 
    }
    public async Task Add(Plane plane)
    {        
      _context.Planes.Add(plane);
      await _context.SaveChangesAsync();
    }
 
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Planes.FindAsync(id);
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Planes.Remove(itemToRemove);
        await _context.SaveChangesAsync();
    }
 
    public async Task<Plane> Get(int id)
    {
        return await _context.Planes.FindAsync(id);
    }
 
    public async Task<IEnumerable<Plane>> GetAll()
    {
        return await _context.Planes.ToListAsync();
    }
 
    public async Task Update(Plane plane)
    {
        var itemToUpdate = await _context.Planes.FindAsync(plane.PlaneID);
        if (itemToUpdate == null)
            throw new NullReferenceException();
        itemToUpdate.PlaneID = plane.PlaneID;
        itemToUpdate.Model = plane.Model;
        itemToUpdate.PassangerCap = plane.PassangerCap;
        itemToUpdate.BagCap = plane.BagCap;
        
        await _context.SaveChangesAsync();
 
    }
  }
}