using DailyTaskListApp.Model;
using NUnit.Framework;
using System;

namespace DailyTaskListApp.UnitTesting
{
    [TestFixture]
    [Category("[Unit Test] A DailyTaskList")]
    public class ADailyTaskList
    {
        [Test]
        public void ShouldReportItsDate() {
            var dateTime = new DateTime(2020, 3, 26);
            var timeSpan = new TimeSpan(8, 0, 0);
            var sut = new DailyTaskList(dateTime, timeSpan);

            var actual = sut.Date;
            var expected = "Mar 26, 2020";
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReportTheStartTime() {
            var dateTime = new DateTime(2020, 3, 26);
            var timeSpan = new TimeSpan(8, 0, 0);
            var sut = new DailyTaskList(dateTime, timeSpan);

            var actual = sut.StartTime;
            var expected = "8:00am";
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReportTheNumberOfTasks() {
            const int NUMBER_OF_TASKS = 11;

            var dateTime = new DateTime(2020, 3, 26);
            var timeSpan = new TimeSpan(8, 0, 0);
            var sut = new DailyTaskList(dateTime, timeSpan);

            sut.Generate<FakeTaskItem>(NUMBER_OF_TASKS);

            var actual = sut.NumberOfTasks;
            var expected = NUMBER_OF_TASKS;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
