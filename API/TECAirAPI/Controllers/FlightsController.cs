using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;

/// <summary>
/// flight Controller with logic of its methods
/// </summary>

namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FlightsController : ControllerBase //Base Controller implementation
  {
    private readonly IFlightRepository _flightRepository; //Flight Repository implementation
    public FlightsController(IFlightRepository flightRepository)
    {
      _flightRepository = flightRepository;
    }
 
    /// <summary>
    /// Get method of all flights
    /// </summary>
    /// <returns>All flights in database</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
    {
        var flights = await _flightRepository.GetAll(); //Get all Flight in database
        return Ok(flights); //Returns Flight
    }
 
    /// <summary>
    /// Get method of a specific flight
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Required flight by ID</returns>

    [HttpGet("{id}")]
    public async Task<ActionResult<Flight>> GetFlight(int id)
    {
        var flight = await _flightRepository.Get(id); //Gets a flight by its ID
        if(flight == null)
            return NotFound();
 
        return Ok(flight); //Returns flight and acceptance
    }
 
    [HttpPost]
    public async Task<ActionResult> CreateFlight(CreateFlightDto createFlightDto)
    {
        Flight flight = new()
        {
            FlightID = createFlightDto.FlightID,
            BagQuantity = createFlightDto.BagQuantity,
            UserQuantity = createFlightDto.UserQuantity,
            Gate = createFlightDto.Gate,
            DepartureTime = createFlightDto.DepartureTime,
            ArrivalTime = createFlightDto.ArrivalTime,
            Origin = createFlightDto.Origin,
            Destination = createFlightDto.Destination,
            Stops = createFlightDto.Stops,
            Status = createFlightDto.Status,
            Price = createFlightDto.Price,
            Discount = createFlightDto.Discount,

        };
 
        await _flightRepository.Add(flight);
        return Ok();
    }
 
    /// <summary>
    /// Method to delete flight by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Acceptance from Task</returns>

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFlight(int id)
    {
        await _flightRepository.Delete(id); //Deletes Flight by its ID
        return Ok(); //Returns acceptance
    }
 
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateFlight(int id, UpdateFlightDto updateFlightDto)
    {
        Flight flight = new()
        {
            FlightID = updateFlightDto.FlightID,
            BagQuantity = updateFlightDto.BagQuantity,
            UserQuantity = updateFlightDto.UserQuantity,
            Gate = updateFlightDto.Gate,
            DepartureTime = updateFlightDto.DepartureTime,
            ArrivalTime = updateFlightDto.ArrivalTime,
            Origin = updateFlightDto.Origin,
            Destination = updateFlightDto.Destination,
            Stops = updateFlightDto.Stops,
            Status = updateFlightDto.Status,
            Price = updateFlightDto.Price,
            Discount = updateFlightDto.Discount,
        };
 
        await _flightRepository.Update(flight);
        return Ok();
    }
  }
}