using System.Collections.Generic;
using System.Threading.Tasks;
using TECAirAPI.Models;
 
 /// <summary>
 /// Interface with implemented methods for Worker entity
 /// </summary>
 
namespace TECAirAPI.Repositories
{
    public interface IWorkerRepository
    {
        Task<Worker> Get(int id); //Initialization of single value Get
        Task<IEnumerable<Worker>> GetAll(); //Initialization of multi valuated Get
        Task Add(Worker worker); //Initialization of Post
        Task Delete(int id); //Initialization of Delete
        Task Update(Worker worker); //Initialization of Put 
    }
}