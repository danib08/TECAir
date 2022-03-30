using System.Collections.Generic;
using System.Threading.Tasks;
using TECAirAPI.Models;

/// <summary>
/// Interface with implemented methods for User entity
/// </summary>

namespace TECAirAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(int id); //Initialization of single value Get
        Task<IEnumerable<User>> GetAll(); //Initialization of multi valuated Get
        Task Add(User user); //Initialization of Post
        Task Delete(int id); //Initialization of Delete
        Task Update(User user); //Initialization of Put
    }
}