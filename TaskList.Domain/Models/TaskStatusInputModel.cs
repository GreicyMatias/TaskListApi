using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskList.Domain.Enums;

namespace TaskList.Domain.Models
{
    public class TaskStatusInputModel
    {
        public Int32 Id { get; set; }

        public TaskStatus Status { get; set; }
    }
}
