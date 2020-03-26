using System;

namespace DailyTaskListApp.Model
{
    public interface ITaskItem
    {
        public DateTime StartTime { get; set; }

        public string StartTimeString { get; }
    }
}