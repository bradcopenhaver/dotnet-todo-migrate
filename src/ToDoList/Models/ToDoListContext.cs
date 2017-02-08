using Microsoft.EntityFrameworkCore;


namespace ToDoList.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext()
        {

        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ToDoList;integrated security=True;");
        }

        public ToDoListContext(DbContextOptions<ToDoListContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}