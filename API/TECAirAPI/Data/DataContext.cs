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
    }
}