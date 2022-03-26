using System.Collections.Generic;
using System.Threading.Tasks;
using TECAirAPI.Models;
 
namespace TECAirAPI.Repositories
{
    public interface IWorkerRepository
    {
        Task<Worker> Get(int id);
        Task<IEnumerable<Worker>> GetAll();
        Task Add(Worker worker);
        Task Delete(int id);
        Task Update(Worker worker);
    }
}