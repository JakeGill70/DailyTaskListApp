using DailyTaskListApp.Model;
using NUnit.Framework;
using System;

namespace DailyTaskListApp.IntegrationTesting
{
    [TestFixture]
    [Category("[Integration Test] A DailyTaskList and a TaskItem")]
    public class ADailyTaskListAndATaskItem
    {
        [Test]
        public void ShouldReportTheEndTime()
        {
            var dateTime = new DateTime(2020, 3, 26);
            var timeSpan = new TimeSpan(8, 0, 0);
            var sut = new DailyTaskList(dateTime, timeSpan);

            sut.Generate<TaskItem>(11);

            var actual = sut.EndTime;
            var expected = "1:00pm";
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
