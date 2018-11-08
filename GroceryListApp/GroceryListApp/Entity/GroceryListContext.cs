using Microsoft.EntityFrameworkCore;
using GroceryListApp.Model;

namespace GroceryListApp.Entity
{
    public class GroceryListContext : DbContext
    {
        public GroceryListContext(DbContextOptions<GroceryListContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryListEntity>().HasKey(k => k.ID);
        }

        public DbSet<GroceryListEntity> GroceryList { get; set; }
    }
}
