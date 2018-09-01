using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Domain.Enums;

namespace TaskList.Domain.Models
{
    public class TaskEventOutputModel
    {
        public DateTime Date { get; set; }

        public TaskEventType Type { get; set; }      
    }
}
