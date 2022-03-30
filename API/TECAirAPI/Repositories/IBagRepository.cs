using System.Collections.Generic;
using System.Threading.Tasks;
using TECAirAPI.Models;
 
/// <summary>
/// Interface with implemented methods for Bag entity
/// </summary>

namespace TECAirAPI.Repositories
{
    public interface IBagRepository
    {
        Task<Bag> Get(int id); //Initialization of single value Get
        Task<IEnumerable<Bag>> GetAll(); //Initialization of multi valuated Get
        Task Add(Bag bag); //Initialization of Post
        Task Delete(int id); //Initialization of Delete
        Task Update(Bag bag); //Initialization of Put
    }
}