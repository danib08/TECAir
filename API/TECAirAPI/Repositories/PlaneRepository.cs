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
  public class PlaneRepository : IPlaneRepository //Implementing the Plane repository methods
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
      _context.Planes.Add(plane); //Adds a Plane in the database
      await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method Delete to eliminate Planes from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Planes.FindAsync(id);  //Finds the object by its ID
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Planes.Remove(itemToRemove); //Remove object idetnified by itemToRemove
        await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method to GET  a specific Plane
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The desire Plane object accessed by its ID</returns>
    public async Task<Plane> Get(int id)
    {
        return await _context.Planes.FindAsync(id); //Finds the object by its ID
    }
 
    /// <summary>
    /// Method to GET all Plane
    /// </summary>
    /// <returns>All the Plane in the database</returns>

    public async Task<IEnumerable<Plane>> GetAll()
    {
        return await _context.Planes.ToListAsync(); //Converts to a list all items from data context
    }

    /// <summary>
    /// Method to Update a Plane
    /// </summary>
    /// <param name="plane"></param>
    /// <returns></returns>
 
    public async Task Update(Plane plane)
    {
        var itemToUpdate = await _context.Planes.FindAsync(plane.PlaneID); //Finds the Seat by its ID
        if (itemToUpdate == null)
            throw new NullReferenceException();

        itemToUpdate.PlaneID = plane.PlaneID; //Updates the Plane ID
        itemToUpdate.Model = plane.Model; //Updates the Plane Model
        itemToUpdate.PassangerCap = plane.PassangerCap; //Updates the Plane Passanger cap
        itemToUpdate.BagCap = plane.BagCap; //Updates the Plane bag cap

         await _context.SaveChangesAsync(); //Save changes
 
    }
  }
}