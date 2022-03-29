using System.Collections.Generic;
using System.Threading.Tasks;
using TECAirAPI.Models;
 
namespace TECAirAPI.Repositories
{
    public interface IBagRepository
    {
        Task<Bag> Get(int id);
        Task<IEnumerable<Bag>> GetAll();
        Task Add(Bag bag);
        Task Delete(int id);
        Task Update(Bag bag);
    }
}