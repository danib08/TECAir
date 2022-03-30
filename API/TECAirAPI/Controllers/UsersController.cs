using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECAirAPI.Dtos;
using TECAirAPI.Models;
using TECAirAPI.Repositories;

/// <summary>
/// User Controller with logic of its methods
/// </summary>

namespace TECAirAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase //Base Controller implementation
  {
    private readonly IUserRepository _userRepository; //User Repository implementation
    public UsersController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }
 
    /// <summary>
    /// Get method of all users
    /// </summary>
    /// <returns>All users in database</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userRepository.GetAll(); //Get all Users in database
        return Ok(users); //Returns Users
    }
 
    /// <summary>
    /// Get method of a specific user
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Required user by ID</returns>

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userRepository.Get(id); //Gets a User by its ID
        if(user == null)
            return NotFound();
 
        return Ok(user); //Returns User and acceptance
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
    /// Method to delete user by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Acceptance from Task</returns>

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _userRepository.Delete(id); //Deletes user by its ID
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