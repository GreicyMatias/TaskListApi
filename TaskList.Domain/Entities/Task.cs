using System;
using System.Collections.Generic;
using TaskList.Domain.Enums;
using TaskList.Domain.Models;

namespace TaskList.Domain.Entities
{
    public class Task
    {
        public Task()
        {
            Events = new List<TaskEvent>();
        }

        public Int32 Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public TaskStatus Status { get; set; }

        public virtual IList<TaskEvent> Events { get; set; }

        public void AddEvent(TaskStatus status)
        {
            Events.Add(new TaskEvent(DateTime.Now, status));

            Status = status;
        }
    }
}
