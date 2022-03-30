using System.Threading.Tasks;
using TECAirAPI.Models;

namespace TECAirAPI.Repositories
{
    public interface IUserRepository
    {
         Task<User> Get(int id); //Initialization of single value Get
        Task<System.Collections.Generic.IEnumerable<User>> GetAll(); //Initialization of multi valuated Get
        Task Add(User user); //Initialization of Post
        Task Delete(int id); //Initialization of Delete
        Task Update(User user); //Initialization of Put
    }
}