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
  public class FlightRepository : IFlightRepository //Implementing the flight repository methods
  {
    private readonly IDataContext _context; //Definition of context from data context
    public FlightRepository(IDataContext context)
    {
      _context = context;
 
    }

    /// <summary>
    /// Mehod POST to create Flight
    /// </summary>
    /// <param name="flight"></param>
    /// <returns></returns>
    public async Task Add(Flight flight)
    {        
      _context.Flights.Add(flight); //Adds a flight in the database
      await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method Delete to eliminate from database 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Flights.FindAsync(id); //Finds the Flight by its ID
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Flights.Remove(itemToRemove); //Remove obejct indetified by itemToRemove
        await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method to GET a specific Flight
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The desire Flight accessed by its ID</returns>
    public async Task<Flight> Get(int id)
    {
        return await _context.Flights.FindAsync(id); //Finds the object by its ID and returns it
    }
 
    /// <summary>
    /// Method to GET all Bags
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Flight>> GetAll()
    {
        return await _context.Flights.ToListAsync(); //Converts to a list all items from database context
    }
 
    /// <summary>
    /// Method to update a flight
    /// </summary>
    /// <param name="flight"></param>
    /// <returns></returns>
    public async Task Update(Flight flight)
    {
        var itemToUpdate = await _context.Flights.FindAsync(flight.FlightID); //Finds the flight by it ID
        if (itemToUpdate == null)
            throw new NullReferenceException();
        itemToUpdate.FlightID = flight.FlightID; //Updates the Flight ID
        itemToUpdate.BagQuantity = flight.BagQuantity; //Updates the Bag Quantity
        itemToUpdate.UserQuantity = flight.UserQuantity; // Updates the User Quantity
        itemToUpdate.Gate = flight.Gate; //Updates the gate
        itemToUpdate.DepartureTime = flight.DepartureTime; //Updates the departure time
        itemToUpdate.DepartureTime = flight.ArrivalTime; //Updates the arrival time 
        itemToUpdate.Origin = flight.Origin; //Updates the origin 
        itemToUpdate.Destination = flight.Destination; //Updates the destination
        itemToUpdate.Stops = flight.Stops; //Update the stops
        itemToUpdate.Status = flight.Status; //Update the status
        itemToUpdate.Price = flight.Price; //Updates the price 
        itemToUpdate.Discount = flight.Discount; // Updates the flight discount

        await _context.SaveChangesAsync(); //Saves changes
 
    }
  }
}