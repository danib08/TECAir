using System.Collections.Generic;
using System.Threading.Tasks;
using TECAirAPI.Models;

namespace TECAirAPI.Repositories
{
    public interface IPlaneRepository
    {
        Task<Plane> Get(int id);
        Task<IEnumerable<Plane>> GetAll();
        Task Add(Plane plane);
        Task Delete(int id);
        Task Update(Plane plane);
    }
}