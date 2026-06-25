using Microsoft.EntityFrameworkCore;
using WebApplication1.Modules.Entities;

namespace WebApplication1.Utility
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options) 
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
 
