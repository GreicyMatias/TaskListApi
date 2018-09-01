using System;
using System.Collections.Generic;
using System.Linq;
using TaskList.Domain.Entities;
using TaskList.EF.Contexts;

namespace TaskList.EF.Repositories
{
    public class TaskRepository
    {
        private TaskListContext context = new TaskListContext();

        public void Add(Task task)
        {
            context.Tasks.Add(task);

            context.SaveChanges();
        }

        public void Remove(Int32 id)
        {
            Task removeTask = context.Tasks.First(x => x.Id == id);
            context.Tasks.Remove(removeTask);

            context.SaveChanges();
        }

        public List<Task> GetAll()
        {
            return context.Tasks.ToList();
        }

        public Task Get(Int32 id)
        {
            return context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStatus(Task task)
        {
            Task update = context.Tasks.First(x => x.Id == task.Id);
            update.Status = task.Status;
            
            context.SaveChanges();
        }
    }
}
