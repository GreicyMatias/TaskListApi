using System;
using TaskList.Domain.Enums;

namespace TaskList.Domain.Entities
{
    public class TaskEvent
    {
        public Int32 Id { get; set; }

        public DateTime Date { get; set; }

        public TaskEventType Type { get; set; }
        
        public virtual Task Task { get; set; }
    }
}
