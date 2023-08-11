using Microsoft.EntityFrameworkCore;

namespace AUG2023_WEBAPI_IBM_AfternoonREACT.Models
{
    public class ToDoItem
    {
        public int ToDoItemID { get; set; }
        public string TaskTitle { get; set; }
    }


    public class ToDoDbContext : DbContext
    {

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

            Database.EnsureCreated();

        }


        public DbSet<ToDoItem> ToDoItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<ToDoItem>().HasKey(x => x.ToDoItemID);
            modelBuilder.Entity<ToDoItem>().Property(x => x.ToDoItemID).ValueGeneratedOnAdd();

            modelBuilder.Entity<ToDoItem>().Property(x => x.TaskTitle).IsRequired().IsUnicode(false).HasMaxLength(50)  ;


            new DbInitializer(modelBuilder).Seed();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

         

        }


    }



    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<ToDoItem>().HasData(
                   new ToDoItem() { ToDoItemID = 1,  TaskTitle="Check Web Ex" },
                    new ToDoItem() { ToDoItemID = 2, TaskTitle = "Finish the App" }
            );
        }
    }




}
