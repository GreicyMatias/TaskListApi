using System;
using TaskList.Domain.Enums;

namespace TaskList.Domain.Models
{
    public class TaskModel
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        //public TaskStatus? Status { get; set; }
    }
}
