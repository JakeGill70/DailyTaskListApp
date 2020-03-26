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
            var sut = new DailyTaskList(new DateTime(2020, 3, 26));

            var actual = sut.Date;
            var expected = "Mar 26, 2020";
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
