using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Data
{
    public class SocialContext: IdentityDbContext<User,Role,int>
    {
        public SocialContext(DbContextOptions<SocialContext> options):base(options)
        {
            
        }  

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}