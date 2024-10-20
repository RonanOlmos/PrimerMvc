using Microsoft.EntityFrameworkCore;
using PrimerMvc.Models;

namespace PrimerMvc.Data
{
    public class PrimerMvcContext : DbContext
    {
        public PrimerMvcContext(DbContextOptions<PrimerMvcContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Piñatas" },
                new Category { Id = 2, Name = "Selfies" }
                );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
