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
  public class PlanesController : ControllerBase
  {
    private readonly IPlaneRepository _planeRepository;
    public PlanesController(IPlaneRepository planeRepository)
    {
      _planeRepository = planeRepository;
    }
 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plane>>> GetPlanes()
    {
        var planes = await _planeRepository.GetAll();
        return Ok(planes);
    }
 
    [HttpGet("{id}")]
    public async Task<ActionResult<Plane>> GetPlane(int id)
    {
        var plane = await _planeRepository.Get(id);
        if(plane == null)
            return NotFound();
 
        return Ok(plane);
    }
 
    [HttpPost]
    public async Task<ActionResult> CreatePlane(CreatePlaneDto createPlaneDto)
    {
        Plane plane = new()
        {
            PlaneID = createPlaneDto.PlaneID,
            Model = createPlaneDto.Model,
            PassangerCap = createPlaneDto.PassangerCap,
            BagCap = createPlaneDto.BagCap,
        };
 
        await _planeRepository.Add(plane);
        return Ok();
    }
 
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePlane(int id)
    {
        await _planeRepository.Delete(id);
        return Ok();
    }
 
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePlane(int id, UpdatePlaneDto updatePlaneDto)
    {
        Plane plane = new()
        {
            PlaneID = updatePlaneDto.PlaneID,
            Model = updatePlaneDto.Model,
            PassangerCap = updatePlaneDto.PassangerCap,
            BagCap = updatePlaneDto.BagCap,
        };
 
        await _planeRepository.Update(plane);
        return Ok();
    }
  }
}