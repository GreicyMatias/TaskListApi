using System;
using TaskList.Domain.Enums;

namespace TaskList.Domain.Entities
{
    public class TaskEvent
    {
        private TaskEvent()
        {

        }

        public TaskEvent(DateTime date, TaskStatus status)
        {
            Date = date;

            switch (status)
            {
                case TaskStatus.Pending:
                case TaskStatus.Processing:
                    Type = TaskEventType.Update;
                    break;
                case TaskStatus.Finished:
                    Type = TaskEventType.Finish;
                    break;
                default:
                    break;
            }
        }

        public Int32 Id { get; set; }

        public DateTime Date { get; set; }

        public TaskEventType Type { get; set; }
        
        public virtual Task Task { get; set; }
    }
}
