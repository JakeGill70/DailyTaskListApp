using DailyTaskListApp.Model;
using System;

namespace DailyTaskListApp.UnitTesting
{
    internal class FakeTaskItem : ITaskItem
    {
        public DateTime StartTime { get; set; }

        public string StartTimeString => throw new NotImplementedException();

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}