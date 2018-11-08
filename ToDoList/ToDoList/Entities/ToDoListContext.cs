using Microsoft.EntityFrameworkCore;

namespace ToDoList.Entities
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<NoteEntity> Notes { get; set; }
    }
}
