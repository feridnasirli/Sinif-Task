using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ContextDb: IdentityDbContext
    {
        public ContextDb(DbContextOptions options):base(options) { }    
       
        public DbSet<Post> Posts { get; set; }
    }
}
