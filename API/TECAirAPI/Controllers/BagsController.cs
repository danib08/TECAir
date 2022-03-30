using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;
 
/// <summary>
/// Bag Controller containing all the logic of each method  
/// </summary>

namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BagsController : ControllerBase //Implementing the BaseController
  {
    private readonly IBagRepository _bagRepository; //Creating a repository of bags
    public BagsController(IBagRepository bagRepository)
    {
      _bagRepository = bagRepository; 
    }
 
    /// <summary>
    /// Method to GET all bags
    /// </summary>
    /// <returns> All the Bags in the Database</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bag>>> GetBags()
    {
        var bags = await _bagRepository.GetAll(); //Get the Bags from the repsoitory
        return Ok(bags); //Returns the bags
    }
 
    /// <summary>
    /// Method to GET a specific bag
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The required bag according to its ID</returns>

    [HttpGet("{id}")]
    public async Task<ActionResult<Bag>> GetBag(int id)
    {
        var bag = await _bagRepository.Get(id);
        if(bag == null)
            return NotFound();
 
        return Ok(bag);
    }
 


    [HttpPost]
    public async Task<ActionResult> CreateBag(CreateBagDto createBagDto)
    {
        Bag bag = new()
        {
            BagID = createBagDto.BagID,
            Weight = createBagDto.Weight,
            Color = createBagDto.Color,
            UserID = createBagDto.UserID,
            FlightID = createBagDto.FlightID,
        };
 
        await _bagRepository.Add(bag);
        return Ok();
    }
 
    /// <summary>
    /// Method to delete a Bag
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Acceptance from task action</returns>

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBag(int id)
    {
        await _bagRepository.Delete(id);
        return Ok();
    }
 
    

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBag(int id, UpdateBagDto updateBagDto)
    {
        Bag bag = new()
        {
            BagID = updateBagDto.BagID,
            Weight = updateBagDto.Weight,
            Color = updateBagDto.Color,
            UserID = updateBagDto.UserID,
            FlightID = updateBagDto.FlightID,
       
        };
 
        await _bagRepository.Update(bag);
        return Ok();
    }
  }
}