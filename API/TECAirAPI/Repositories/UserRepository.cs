using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Data;
using TECAirAPI.Models;
 
namespace TECAirAPI.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly IDataContext _context;
    public UserRepository(IDataContext context)
    {
      _context = context;
 
    }
    public async Task Add(User user)
    {        
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
    }
 
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Users.FindAsync(id);
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Users.Remove(itemToRemove);
        await _context.SaveChangesAsync();
    }
 
    public async Task<User> Get(int id)
    {
        return await _context.Users.FindAsync(id);
    }
 
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }
 
    public async Task Update(User user)
    {
        var itemToUpdate = await _context.Users.FindAsync(user.UserID);
        if (itemToUpdate == null)
            throw new NullReferenceException();
        
        itemToUpdate.UserID = user.UserID;
        itemToUpdate.NameUser = user.NameUser;
        itemToUpdate.LastNameUser = user.LastNameUser;
        itemToUpdate.PassUser = user.PassUser;
        itemToUpdate.Email = user.Email;
        itemToUpdate.Phone = user.Phone;
        itemToUpdate.StudentID = user.StudentID;
        itemToUpdate.University = user.University;
        itemToUpdate.Miles = user.Miles;

        await _context.SaveChangesAsync();
 
    }
  }
}