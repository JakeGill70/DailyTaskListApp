using System;

namespace DailyTaskListApp.Model
{
    public class DailyTaskList
    {
        private DateTime _date;
        public string Date { get { return _date.ToString("MMM dd, yyyy"); } }
        public DailyTaskList(DateTime dateTime)
        {
            _date = dateTime;
        }

        
    }
}