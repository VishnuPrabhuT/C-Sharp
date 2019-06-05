using Microsoft.EntityFrameworkCore;
using GroceryListVue.Model;

namespace GroceryListVue.Entity
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

        public DbSet<GroceryListVue.Model.GroceryListModel> GroceryListModel { get; set; }
    }
}
