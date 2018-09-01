using System.Configuration;
using System.Data.Entity;
using TaskList.Domain.Entities;
using TaskList.EF.Configurations;

namespace TaskList.EF.Contexts
{
    public class TaskListContext : DbContext
    {
        public TaskListContext() : base("MainDatabase")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskEvent> TaskEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Configurations.Add(new TaskConfiguration());
        }
    }
}
