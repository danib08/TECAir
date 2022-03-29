using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Models;

namespace TECAirAPI.Data
{
    public interface IDataContext
    {
         DbSet<Worker> Workers { get; init; }
        DbSet<Bag> Bags { get; init; }
        DbSet<Plane> Planes { get; init; }

        DbSet<Seat> Seats { get; init; }
        DbSet<User> Users { get; init; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}