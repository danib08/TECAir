using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;

/// <summary>
/// Planes Controller with the logic of every method
/// </summary>

namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PlanesController : ControllerBase //Base Controller Implementation
  {
    private readonly IPlaneRepository _planeRepository; //Plane Repository Implementation
    public PlanesController(IPlaneRepository planeRepository)
    {
      _planeRepository = planeRepository;
    }
 
    /// <summary>
    /// Method to GET all the Planes
    /// </summary>
    /// <returns>All planes from database</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plane>>> GetPlanes()
    {
        var planes = await _planeRepository.GetAll(); //Gets planes from repository
        return Ok(planes); //Returns acceptance and planes
    }
 
    /// <summary>
    /// Method to GET a specific plane
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Required plane by its ID</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Plane>> GetPlane(int id)
    {
        var plane = await _planeRepository.Get(id); //Gets the plane from the repository
        if(plane == null)
            return NotFound();
 
        return Ok(plane); //Returns acceptance and Plane
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
    /// Method to Delete Planes by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Acceptance from Task</returns>

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePlane(int id) 
    {
        await _planeRepository.Delete(id); //Deletes the plane
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