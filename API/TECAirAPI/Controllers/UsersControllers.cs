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
  public class UsersController : ControllerBase
  {
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }
 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userRepository.GetAll();
        return Ok(users);
    }
 
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userRepository.Get(id);
        if(user == null)
            return NotFound();
 
        return Ok(user);
    }
 
    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserDto createUserDto)
    {
        User user = new()
        {
            
            UserID = createUserDto.UserID,
            NameUser = createUserDto.NameUser,
            LastNameUser = createUserDto.LastNameUser,
            PassUser = createUserDto.PassUser,
            Email = createUserDto.Email,
            Phone = createUserDto.Phone,
            StudentID = createUserDto.StudentID,
            University = createUserDto.University,
            Miles = createUserDto.Miles,

        };
 
        await _userRepository.Add(user);
        return Ok();
    }
 
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _userRepository.Delete(id);
        return Ok();
    }
 
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        User user = new()
        {
            UserID = updateUserDto.UserID,
            NameUser = updateUserDto.NameUser,
            LastNameUser = updateUserDto.LastNameUser,
            PassUser = updateUserDto.PassUser,
            Email = updateUserDto.Email,
            Phone = updateUserDto.Phone,
            StudentID = updateUserDto.StudentID,
            University = updateUserDto.University,
            Miles = updateUserDto.Miles,
        };
 
        await _userRepository.Update(user);
        return Ok();
    }
  }
}