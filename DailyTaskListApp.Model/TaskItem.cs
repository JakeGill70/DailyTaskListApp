using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskListApp.Model
{
    public class TaskItem : ITaskItem
    {
        public DateTime StartTime { get; set; }
    }
}
