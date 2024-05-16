using BuckyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BuckyBook.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { id=1 , name="Action" , displayOrder=1},
                new Category { id = 2, name = "Scifi", displayOrder = 2 },
                new Category { id = 3, name = "History", displayOrder = 3 },
                new Category { id = 4, name = "Dramatic", displayOrder = 4 }
                );
        }
    }
}