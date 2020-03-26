using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyTaskListApp.Model
{
    public class DailyTaskList
    {
        private DateTime _date;
        private ICollection<ITaskItem> _tasks = new List<ITaskItem>();


        public string Date { get { return _date.ToString("MMM dd, yyyy"); } }
        public object StartTime { get { return _date.ToString("h:mmtt").ToLowerInvariant(); } }

        public object EndTime { get { return _tasks.Last<ITaskItem>().StartTime.ToString("h:mmtt").ToLowerInvariant(); } }

        public DailyTaskList(DateTime date, TimeSpan startTime)
        {
            _date = date.Date + startTime;
        }

        public void Generate<T>(int numberOfHalfHourSegments) where T : ITaskItem, new()
        {
            var startTime = _date;
            for (var segment = 0; segment < numberOfHalfHourSegments; segment++)
            {
                _tasks.Add(new T { StartTime = startTime });
                startTime = startTime.AddMinutes(30);
            }
        }

    }
}