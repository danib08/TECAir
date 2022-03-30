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
  public class FlightRepository : IFlightRepository //Implementing the Flight repository methods
  {
    private readonly IDataContext _context; //Definition of context from data context
    public FlightRepository(IDataContext context) 
    {
      _context = context;
 
    }

    /// <summary>
    /// Method Post to create Flights
    /// </summary>
    /// <param name="flight"></param>
    /// <returns></returns>
    public async Task Add(Flight flight)
    {        
      _context.Flights.Add(flight); //Adds a Flight in the database
      await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method Delete to eliminate Flights from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Flights.FindAsync(id); //Finds the object by its ID
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Flights.Remove(itemToRemove); //Remove object idetnified by itemToRemove
        await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method to GET a specific Flight
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The desire Flight object accessed by its ID</returns>
    public async Task<Flight> Get(int id)
    {
        return await _context.Flights.FindAsync(id); //Finds the object by its ID
    }
 
    /// <summary>
    /// Method to GET all Flights
    /// </summary>
    /// <returns>All the objects in the database</returns>
    public async Task<IEnumerable<Flight>> GetAll()
    {
        return await _context.Flights.ToListAsync(); //Converts to a list all items from data context
    }
 
    /// <summary>
    /// Method to Update a Flight
    /// </summary>
    /// <param name="flight"></param>
    /// <returns></returns>
    public async Task Update(Flight flight)
    {
        var itemToUpdate = await _context.Flights.FindAsync(flight.FlightID); //Finds the Bags by its ID
        if (itemToUpdate == null)
            throw new NullReferenceException();
       
        itemToUpdate.FlightID = flight.FlightID; //Updates the Bag ID
        itemToUpdate.BagQuantity = flight.BagQuantity;
        itemToUpdate.UserQuantity = flight.UserQuantity;
        itemToUpdate.Gate = flight.Gate;
        itemToUpdate.DepartureTime = flight.DepartureTime;
        itemToUpdate.ArrivalTime = flight.ArrivalTime;
        itemToUpdate.Origin = flight.Origin;
        itemToUpdate.Destination = flight.Destination;
        itemToUpdate.Stops = flight.Stops;
        itemToUpdate.Status = flight.Status;
        itemToUpdate.Discount = flight.Discount;
        itemToUpdate.Price = flight.Price;

        //itemToUpdate.UserID = bag.UserID; //Updates the UserID
       // itemToUpdate.FlightID = bag.FlightID; //Updates the Flight

        await _context.SaveChangesAsync(); //Save changes
 
    }
  }
}