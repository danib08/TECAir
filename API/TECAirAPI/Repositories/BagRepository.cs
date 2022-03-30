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
  public class BagRepository : IBagRepository //Implementing the bag repository methods
  {
    private readonly IDataContext _context; //Definition of context from data context
    public BagRepository(IDataContext context) 
    {
      _context = context;
 
    }

    /// <summary>
    /// Method Post to create Bags
    /// </summary>
    /// <param name="bag"></param>
    /// <returns></returns>
    public async Task Add(Bag bag)
    {        
      _context.Bags.Add(bag); //Adds a bag in the database
      await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method Delete to eliminate Bags from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Bags.FindAsync(id); //Finds the object by its ID
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Bags.Remove(itemToRemove); //Remove object idetnified by itemToRemove
        await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method to GET a specific Bag
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The desire Bag object accessed by its ID</returns>
    public async Task<Bag> Get(int id)
    {
        return await _context.Bags.FindAsync(id); //Finds the object by its ID
    }
 
    /// <summary>
    /// Method to GET all Bags
    /// </summary>
    /// <returns>All the objects in the database</returns>
    public async Task<IEnumerable<Bag>> GetAll()
    {
        return await _context.Bags.ToListAsync(); //Converts to a list all items from data context
    }
 
    /// <summary>
    /// Method to Update a Bag
    /// </summary>
    /// <param name="bag"></param>
    /// <returns></returns>
    public async Task Update(Bag bag)
    {
        var itemToUpdate = await _context.Bags.FindAsync(bag.BagID); //Finds the Bags by its ID
        if (itemToUpdate == null)
            throw new NullReferenceException();
       
        itemToUpdate.BagID = bag.BagID; //Updates the Bag ID
        itemToUpdate.Weight = bag.Weight; //Updates the weight
        itemToUpdate.Color = bag.Color; //Updates the color
        itemToUpdate.UserID = bag.UserID; //Updates the UserID
        itemToUpdate.FlightID = bag.FlightID; //Updates the Flight

        await _context.SaveChangesAsync(); //Save changes
 
    }
  }
}