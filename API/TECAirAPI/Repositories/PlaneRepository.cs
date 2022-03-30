using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Data;
using TECAirAPI.Models;

/// <summary>
/// Plane repository implementing Data context and interface methods
/// </summary>

namespace TECAirAPI.Repositories
{
  public class PlaneRepository : IPlaneRepository //Implementing the plane repository methods
  {
    private readonly IDataContext _context; //Definition of context from data context
    public PlaneRepository(IDataContext context)
    {
      _context = context;
 
    }
    /// <summary>
    /// Method Post to create Plane
    /// </summary>
    /// <param name="plane"></param>
    /// <returns></returns>
    public async Task Add(Plane plane)
    {        
      _context.Planes.Add(plane);
      await _context.SaveChangesAsync();
    }
 
    /// <summary>
    /// Method Delete to eliminate Plane from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Planes.FindAsync(id); //Finds the object by its ID
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Planes.Remove(itemToRemove); //Removes the object identified by itemToRemove
        await _context.SaveChangesAsync(); //Saves Changes
    }
 
    /// <summary>
    /// Method to GET a specific Bag
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The desired Flight object accessed by its ID</returns>
    public async Task<Plane> Get(int id)
    {
        return await _context.Planes.FindAsync(id); //Finds the object by its ID
    }
 
    /// <summary>
    /// Method to GET all Fights
    /// </summary>
    /// <returns>All the objects in the database</returns>
    public async Task<IEnumerable<Plane>> GetAll()
    {
        return await _context.Planes.ToListAsync(); //Converts to a list all items from database
    }
 
    /// <summary>
    /// Method to Update a Flight
    /// </summary>
    /// <param name="plane"></param>
    /// <returns></returns>
    public async Task Update(Plane plane)
    {
        var itemToUpdate = await _context.Planes.FindAsync(plane.PlaneID); //Find the Plane by its ID
        if (itemToUpdate == null)
            throw new NullReferenceException();

        itemToUpdate.PlaneID = plane.PlaneID; //Updates the Plane ID
        itemToUpdate.Model = plane.Model; //Updates the weight
        itemToUpdate.PassangerCap = plane.PassangerCap; //Updates the Passanger Cap
        itemToUpdate.BagCap = plane.BagCap; //Updates the Bag Cap
        
        await _context.SaveChangesAsync(); //Save changes
 
    }
  }
}