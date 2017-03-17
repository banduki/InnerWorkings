using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InnerWorkingsCodeAssignment.Tests
{
    [TestClass]
    public class JobCalculatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JobCalculator_GivenNullJobProperties_ThrowsArgumentNullException()
        {
            new JobCalculator(null);
        }

        [TestMethod]
        public void Total_GivenNoItems_ReturnZero()
        {
            var properties = JobPropertiesForTest(new List<JobItem>());
            var actual = new JobCalculator(properties).Total;

            Assert.AreEqual(0m, actual);
        }

        [TestMethod]
        public void Total_GivenNonExemptItemAndNoExtraMargin_Return118()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100m, false)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, false)).Total;

            Assert.AreEqual(118m, actual);
        }

        [TestMethod]
        public void Total_GivenNonExemptItemAndExtraMargin_Return124()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100m, false)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, true)).Total;

            Assert.AreEqual(123m, actual);
        }

        [TestMethod]
        public void Total_GivenExemptItemAndNoExtraMargin_Return111()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100m, true)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, false)).Total;

            Assert.AreEqual(111m, actual);
        }

        [TestMethod]
        public void Total_GivenExemptItemAndExtraMargin_ReturnTotalOf116()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100m, true)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, true)).Total;

            Assert.AreEqual(116m, actual);
        }

        [TestMethod]
        public void Total_GivenAnItem_CalculateTotalToNearestEvenCent()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100.04m, false)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, true)).Total;

            Assert.AreEqual(123.04m, actual);
        }

        [TestMethod]
        public void Output_GivenTwoItemsAnd200Total_ProduceExpectedOutput()
        {
            const string Expected = "envelopes: $556.40\nletterhead: $1983.37\ntotal: $2940.30";
            var items = new List<JobItem>
            {
                new JobItem("envelopes", 520, false),
                new JobItem("letterhead", 1983.37m, true)
            };
            var subject = new JobCalculator(JobPropertiesForTest(items, true));

            var actual = subject.Output;

            Assert.AreEqual(Expected, actual);
        }

        #region Test helpers

        private JobProperties JobPropertiesForTest(List<JobItem> list, bool extraMargin = false)
        {
            return new JobProperties(list, 0.07m, 0.11m, extraMargin, 0.05m);
        }

        #endregion Test helpers
    }
}
