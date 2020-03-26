using System;
using System.Collections.Generic;

namespace DailyTaskListApp.Model
{
    public class DailyTaskList
    {
        private DateTime _date;
        private ICollection<ITaskItem> _tasks = new List<ITaskItem>();


        public string Date { get { return _date.ToString("MMM dd, yyyy"); } }
        public object StartTime { get { return _date.ToString("h:mmtt").ToLowerInvariant(); } }

        public DailyTaskList(DateTime date, TimeSpan startTime)
        {
            _date = date.Date + startTime;
        }

        
    }
}