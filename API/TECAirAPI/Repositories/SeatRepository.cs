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
  public class SeatRepository : ISeatRepository //Implementing the seat repository methods
  {
    private readonly IDataContext _context; //Definition of context from data context
    public SeatRepository(IDataContext context)
    {
      _context = context;
 
    }

    /// <summary>
    /// Method Post to create Seatss
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
        var itemToRemove = await _context.Seats.FindAsync(id);  //Finds the object by its ID
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Seats.Remove(itemToRemove); //Remove object idetnified by itemToRemove
        await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method to GET  a specific seat
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The desire seat object accessed by its ID</returns>
    public async Task<Seat> Get(int id)
    {
        return await _context.Seats.FindAsync(id); //Finds the object by its ID
    }
 
    /// <summary>
    /// Method to GET all seats
    /// </summary>
    /// <returns>All the seats in the database</returns>

    public async Task<IEnumerable<Seat>> GetAll()
    {
        return await _context.Seats.ToListAsync(); //Converts to a list all items from data context
    }

    /// <summary>
    /// Method to Update a seat
    /// </summary>
    /// <param name="seat"></param>
    /// <returns></returns>
 
    public async Task Update(Seat seat)
    {
        var itemToUpdate = await _context.Seats.FindAsync(seat.SeatID); //Finds the Seat by its ID
        if (itemToUpdate == null)
            throw new NullReferenceException();
        itemToUpdate.SeatID = seat.SeatID; //Updates the Seat ID

         await _context.SaveChangesAsync(); //Save changes
 
    }
  }
}