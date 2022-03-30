using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Data;
using TECAirAPI.Models;

/// <summary>
/// Repository implementing Data context and interface methods 
/// </summary>

namespace TECAirAPI.Repositories
{
  public class UserRepository : IUserRepository //Implementing the bag repository methods
  {
    private readonly IDataContext _context; //Definition of context from data context
    public UserRepository(IDataContext context)
    {
      _context = context;
 
    }
    /// <summary>
    /// Method Post to create Users
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task Add(User user)
    {        
      _context.Users.Add(user); //Adds an user in the database
      await _context.SaveChangesAsync(); //Save changes
    }

    /// <summary>
    /// Method Delete to eliminate User from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task Delete(int id)  
    {
        var itemToRemove = await _context.Users.FindAsync(id); //Finds the object by it ID
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Users.Remove(itemToRemove); //Remove object identified by itemToRemove
        await _context.SaveChangesAsync(); //Saves changes
    }
 
    /// <summary>
    /// Method to GET a specific User
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The desire User object accessed by its ID</returns>
    public async Task<User> Get(int id)
    {
        return await _context.Users.FindAsync(id);//Finds the object by its ID and returns it
    }
 
    /// <summary>
    /// Method to GET all Users
    /// </summary>
    /// <returns>All the objects in the database</returns>
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync(); //Converts to a list all items from data context
    }
 
    /// <summary>
    /// Method to Update a User 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task Update(User user)
    {
        var itemToUpdate = await _context.Users.FindAsync(user.UserID); //Finds the User by its ID
        if (itemToUpdate == null)
            throw new NullReferenceException();
        
        itemToUpdate.UserID = user.UserID; //Updates the User ID
        itemToUpdate.NameUser = user.NameUser; //Updates the User Name
        itemToUpdate.LastNameUser = user.LastNameUser; //Updates the User's Last Name
        itemToUpdate.PassUser = user.PassUser; //Updates User's password
        itemToUpdate.Email = user.Email; //Updates User's Email
        itemToUpdate.Phone = user.Phone; //Updates User's Phone
        itemToUpdate.StudentID = user.StudentID; //Updates Student ID
        itemToUpdate.University = user.University; //Updates User's University
        itemToUpdate.Miles = user.Miles; //Updates User's Miles

        await _context.SaveChangesAsync(); //Save changes
 
    }
  }
}