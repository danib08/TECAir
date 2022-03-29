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
  public class BagsController : ControllerBase
  {
    private readonly IBagRepository _bagRepository;
    public BagsController(IBagRepository bagRepository)
    {
      _bagRepository = bagRepository;
    }
 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bag>>> GetBags()
    {
        var bags = await _bagRepository.GetAll();
        return Ok(bags);
    }
 
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
            WorkerID = createBagDto.WorkerID
        };
 
        await _bagRepository.Add(bag);
        return Ok();
    }
 
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
            WorkerID = updateBagDto.WorkerID
       
        };
 
        await _bagRepository.Update(bag);
        return Ok();
    }
  }
}