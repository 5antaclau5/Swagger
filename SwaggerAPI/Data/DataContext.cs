using Microsoft.EntityFrameworkCore;
using SwaggerAPI.Entities;

namespace SwaggerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TbEmployee> TbEmployees => Set<TbEmployee>();

    }
}