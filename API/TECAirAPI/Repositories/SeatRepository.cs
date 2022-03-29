using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Data;
using TECAirAPI.Models;
 
namespace TECAirAPI.Repositories
{
  public class SeatRepository : ISeatRepository
  {
    private readonly IDataContext _context;
    public SeatRepository(IDataContext context)
    {
      _context = context;
 
    }
    public async Task Add(Seat seat)
    {        
      _context.Seats.Add(seat);
      await _context.SaveChangesAsync();
    }
 
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Seats.FindAsync(id);
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Seats.Remove(itemToRemove);
        await _context.SaveChangesAsync();
    }
 
    public async Task<Seat> Get(int id)
    {
        return await _context.Seats.FindAsync(id);
    }
 
    public async Task<IEnumerable<Seat>> GetAll()
    {
        return await _context.Seats.ToListAsync();
    }
 
    public async Task Update(Seat seat)
    {
        var itemToUpdate = await _context.Seats.FindAsync(seat.SeatID);
        if (itemToUpdate == null)
            throw new NullReferenceException();
        
        itemToUpdate.SeatID = seat.SeatID;

        await _context.SaveChangesAsync();
 
    }
  }
}