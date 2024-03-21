using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        //Category is model and categories is tablename
        public DbSet<Category> categories { get; set; }

        //default model buldet to show data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DispalyOrder = 1 },
                 new Category { Id = 2, Name = "History", DispalyOrder = 2 },
                  new Category { Id = 3, Name = "Scifi", DispalyOrder = 3 }

                );
        }
    }
}
