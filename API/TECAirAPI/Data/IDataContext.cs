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

        DbSet<Seat> Seats { get; init; } //Setting of Seats in the database
        DbSet<Plane> Planes { get; init; } //Setting of Planes in the database
         DbSet<User> Users { get; init; } //Setting of Users in the database
        DbSet<Flight> Flights { get; init; } //Setting of Flights in the database
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); //Task for saving changes
    }
}