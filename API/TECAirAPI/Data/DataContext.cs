using Microsoft.EntityFrameworkCore;
using TECAirAPI.Models;
 
namespace TECAirAPI.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
             
        }
 
        public DbSet<Worker> Workers { get; init; }
        public DbSet<Bag> Bags { get; init; }
        public DbSet<Plane> Planes { get; init; }
        public DbSet<Seat> Seats { get; init; }
        public DbSet<User> Users { get; init; }


    }
}