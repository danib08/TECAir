using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TECAirAPI.Models;

/// <summary>
/// Creation of the data context as an interface
/// </summary>

namespace TECAirAPI.Data
{
    public interface IDataContext
    {
        DbSet<Worker> Workers { get; init; } //Setting of Workers in the database
        DbSet<Bag> Bags { get; init; } //Setting of Bags in the database


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); //Task for saving changes
    }
}