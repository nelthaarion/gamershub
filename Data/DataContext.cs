using Angular.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular.Data
{
    public class DataContext : DbContext
    {
            public DataContext(DbContextOptions<DataContext> opt) : base (opt)
            {
                
            }    

            public DbSet<User> Users { get; set; } 
    }
}