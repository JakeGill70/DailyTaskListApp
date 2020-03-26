using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskListApp.Model
{
    public class TaskItem : ITaskItem
    {
        string _description = "-";

        public DateTime StartTime { get; set; }

        public string StartTimeString { get { return StartTime.ToString("h:mmtt").ToLowerInvariant(); } }

        public string Description { get { return _description; } set { _description = value; } }
    }
}
