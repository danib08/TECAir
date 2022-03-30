using System.Collections.Generic;
using System.Threading.Tasks;
using TECAirAPI.Models;

/// <summary>
/// Interface with implemented methods for Flight entity
/// </summary>

namespace TECAirAPI.Repositories
{
    public interface IFlightRepository
    {
         Task<Flight> Get(int id);//Initialization of single value Get
        Task<IEnumerable<Flight>> GetAll();//Initialization of multi valuated Get
        Task Add(Flight flight); //Initialization of Post

        Task Delete(int id);//Initialization of Delete
        Task Update(Flight flight);//Initialization of Put
    }
}