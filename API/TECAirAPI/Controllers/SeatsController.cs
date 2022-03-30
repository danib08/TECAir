using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;

/// <summary>
/// Seat Controller with logic of its methods
/// </summary>

namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SeatsController : ControllerBase //Base Controller implementation
  {
    private readonly ISeatRepository _seatRepository; //Seat Repository implementation
    public SeatsController(ISeatRepository seatRepository)
    {
      _seatRepository = seatRepository;
    }
 
    /// <summary>
    /// Get method of all seats
    /// </summary>
    /// <returns>All seats in database</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
    {
        var seats = await _seatRepository.GetAll(); //Get all seats in database
        return Ok(seats); //Returns seats
    }
 
    /// <summary>
    /// Get method of a specific seat
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Required seat by ID</returns>

    [HttpGet("{id}")]
    public async Task<ActionResult<Seat>> GetSeat(int id)
    {
        var seat = await _seatRepository.Get(id); //Gets a seat by its ID
        if(seat == null)
            return NotFound();
 
        return Ok(seat); //Returns seat and acceptance
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
    /// Method to delete seats by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Acceptance from Task</returns>

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSeat(int id)
    {
        await _seatRepository.Delete(id); //Deletes seat by its ID
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