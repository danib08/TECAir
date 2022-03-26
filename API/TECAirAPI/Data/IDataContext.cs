using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Models;

namespace TECAirAPI.Data
{
    public interface IDataContext
    {
         DbSet<Worker> workers { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}