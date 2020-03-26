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

        [TestCase(0, "10:00am")]
        [TestCase(1, "10:30am")]
        [TestCase(2, "11:00am")]
        [TestCase(3, "11:30am")]
        [TestCase(4, "12:00pm")]
        [TestCase(5, "12:30pm")]
        public void ShouldReportEachTaskStartTimeAsAString(int index, string expectedTime)
        {
            var sut = new DailyTaskList(new DateTime(2020, 3, 26), new TimeSpan(10, 0, 0));
            sut.Generate<TaskItem>(6);
            Assert.That(sut[index].StartTimeString, Is.EqualTo(expectedTime));
        }

    }
}
