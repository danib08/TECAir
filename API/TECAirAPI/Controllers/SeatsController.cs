using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;
 
namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SeatsController : ControllerBase
  {
    private readonly ISeatRepository _seatRepository;
    public SeatsController(ISeatRepository seatRepository)
    {
      _seatRepository = seatRepository;
    }
 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
    {
        var seats = await _seatRepository.GetAll();
        return Ok(seats);
    }
 
    [HttpGet("{id}")]
    public async Task<ActionResult<Seat>> GetSeat(int id)
    {
        var seat = await _seatRepository.Get(id);
        if(seat == null)
            return NotFound();
 
        return Ok(seat);
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
 
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSeat(int id)
    {
        await _seatRepository.Delete(id);
        return Ok();
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