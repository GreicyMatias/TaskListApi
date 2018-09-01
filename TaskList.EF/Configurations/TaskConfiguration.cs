using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TaskList.Domain.Entities;

namespace TaskList.EF.Configurations
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            ToTable("Tasks");

            HasKey(s => s.Id);

            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Description)
                    .HasMaxLength(100);
            
            HasMany(task => task.Events)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete();
        }
    }
}
