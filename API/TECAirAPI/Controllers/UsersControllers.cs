using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;
 
/// <summary>
/// User Controller with logic of methods
/// </summary>

namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase //Base Controller Implementation
  {
    private readonly IUserRepository _userRepository; //Repository implementation
    public UsersController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }
 
    /// <summary>
    /// Method to get al Users
    /// </summary>
    /// <returns>All Users in database</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userRepository.GetAll(); //Gets all users from repository
        return Ok(users); //Returns users and acceptance
    }
 
    /// <summary>
    /// Method to get a specific User
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Required user by ID</returns>
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userRepository.Get(id); //Gets user by ID
        if(user == null)
            return NotFound();
 
        return Ok(user); //Returns acceptance and user
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
 
    /// <summary>
    /// Method to delete users by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Acceptance from Task</returns>
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _userRepository.Delete(id); //Deletes user from repository
        return Ok(); //Returns acceptance
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