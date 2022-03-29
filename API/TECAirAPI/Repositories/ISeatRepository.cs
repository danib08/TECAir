using System.Collections.Generic;
using System.Threading.Tasks;
using TECAirAPI.Models;

namespace TECAirAPI.Repositories
{
    public interface ISeatRepository
    {
         Task<Seat> Get(int id);
        Task<IEnumerable<Seat>> GetAll();
        Task Add(Seat seat);
        Task Delete(int id);
        Task Update(Seat seat);
    }
}