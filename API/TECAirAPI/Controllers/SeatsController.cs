using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;
 
/// <summary>
/// Seat Controller with the logic of every method
/// </summary>

namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SeatsController : ControllerBase //Base Controller implementation
  {
    private readonly ISeatRepository _seatRepository; // Seat Repository implementatios
    public SeatsController(ISeatRepository seatRepository)
    {
      _seatRepository = seatRepository;
    }
 
    /// <summary>
    /// Method to get all Seats 
    /// </summary>
    /// <returns>All seats</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
    {
        var seats = await _seatRepository.GetAll(); //Gets all seats from repository
        return Ok(seats); //Returns acceptance and seats
    }
 
    /// <summary>
    /// Method to get a specific Seat 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Required seat by ID</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Seat>> GetSeat(int id)
    {
        var seat = await _seatRepository.Get(id); //Gets sea from repository from ID
        if(seat == null)
            return NotFound();
 
        return Ok(seat); //Returns acceptance and seats
    }
 
    [HttpPost]
    public async Task<ActionResult> CreateSeat(CreateSeatDto createSeatDto)
    {
        Seat seat = new()
        {
            SeatID = createSeatDto.SeatID,

        };
 
        await _seatRepository.Add(seat);
        return Ok();
    }
 
    /// <summary>
    /// Method to delete Seats by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Acceptance from Task</returns>

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSeat(int id)
    {
        await _seatRepository.Delete(id); //Deletes seat by ID
        return Ok(); //Returns acceptance
    }
 
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSeat(int id, UpdateSeatDto updateSeatDto)
    {
        Seat seat = new()
        {
            
            SeatID = updateSeatDto.SeatID,
            
            

        };
 
        await _seatRepository.Update(seat);
        return Ok();
    }
  }
}