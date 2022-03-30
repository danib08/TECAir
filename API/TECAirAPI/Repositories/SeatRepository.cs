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
  public class SeatRepository : ISeatRepository //Implementing the bag repository methods
  {
  
    private readonly IDataContext _context; //Definition of context from data context
    public SeatRepository(IDataContext context)
    {
      _context = context;
 
    }

    /// <summary>
    /// Method Post to create Seats
    /// </summary>
    /// <param name="seat"></param>
    /// <returns></returns>
    public async Task Add(Seat seat)
    {        
      _context.Seats.Add(seat); //Adds a seat in the database
      await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method Delete to eliminate Seats from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Seats.FindAsync(id); //Finds the object by its ID
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Seats.Remove(itemToRemove); //Remove object idetnified by itemToRemove
        await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method to GET a specific Plane
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The desire Seat object accessed by its ID</returns>
    public async Task<Seat> Get(int id)
    {
        return await _context.Seats.FindAsync(id); //Finds the object by its ID
    }
 
    /// <summary>
    /// Method to GET all Seat
    /// </summary>
    /// <returns>All the objects in the database</returns>
    public async Task<IEnumerable<Seat>> GetAll()
    {
        return await _context.Seats.ToListAsync(); //Converts to a list all items from data context
    }
 
    /// <summary>
    /// Method tu Update a Seat
    /// </summary>
    /// <param name="seat"></param>
    /// <returns></returns>
    public async Task Update(Seat seat)
    {
        var itemToUpdate = await _context.Seats.FindAsync(seat.SeatID); //Finds the Seats by it ID
        if (itemToUpdate == null)
            throw new NullReferenceException();
        
        itemToUpdate.SeatID = seat.SeatID; //Updates the SeatID

        await _context.SaveChangesAsync(); //Save changes
 
    }
  }
}