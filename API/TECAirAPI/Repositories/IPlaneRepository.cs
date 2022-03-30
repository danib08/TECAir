using System.Collections.Generic;

using System.Threading.Tasks;
using TECAirAPI.Models;

namespace TECAirAPI.Repositories
{
    public interface IPlaneRepository
    {
         Task<Plane> Get(int id); //Initialization of single value Get
        Task<IEnumerable<Plane>> GetAll(); //Initialization of multi valuated Get
        Task Add(Plane plane); //Initialization of Post
        Task Delete(int id); //Initialization of Delete
        Task Update(Plane plane); //Initialization of Put
    }
}

