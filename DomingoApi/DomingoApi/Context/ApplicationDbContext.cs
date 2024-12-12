using DomingoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DomingoApi.Context
{
    public class ApplicationDbContext: DbContext
    {
      
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Producto> Producto { get; set; }
        
    }
}
