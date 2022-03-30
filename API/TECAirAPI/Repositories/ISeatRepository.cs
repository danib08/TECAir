using System.Collections.Generic;
using System.Threading.Tasks;
using TECAirAPI.Models;

/// <summary>
/// Interface with implemented methods for Seat entity
/// </summary>
namespace TECAirAPI.Repositories
{
    public interface ISeatRepository
    {
         Task<Seat> Get(int id); //Initialization of single value Get
        Task<IEnumerable<Seat>> GetAll(); //Initialization of multi valuated Get
        Task Add(Seat seat); //Initialization of Post
        Task Delete(int id); //Initialization of Delete
        Task Update(Seat seat); //Initialization of Put
    }
}