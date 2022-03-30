using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;

/// <summary>
/// Plane Controller with logic of its methods
/// </summary>

namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PlanesController : ControllerBase //Base Controller implementation
  {
    private readonly IPlaneRepository _planeRepository; //Plane Repository implementation
    public PlanesController(IPlaneRepository planeRepository)
    {
      _planeRepository = planeRepository;
    }
 
    /// <summary>
    /// Get method of all planes
    /// </summary>
    /// <returns>All planes in database</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plane>>> GetPlanes()
    {
        var planes = await _planeRepository.GetAll(); //Get all planes in database
        return Ok(planes); //Returns planes
    }
 
    /// <summary>
    /// Get method of a specific plane
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Required plane by ID</returns>

    [HttpGet("{id}")]
    public async Task<ActionResult<Plane>> GetPlane(int id)
    {
        var plane = await _planeRepository.Get(id); //Gets a plane by its ID
        if(plane == null)
            return NotFound();
 
        return Ok(plane); //Returns plane and acceptance
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
 
    /// <summary>
    /// Method to delete Planes by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Acceptance from Task</returns>

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePlane(int id)
    {
        await _planeRepository.Delete(id); //Deletes worker by its ID
        return Ok(); //Returns acceptance
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