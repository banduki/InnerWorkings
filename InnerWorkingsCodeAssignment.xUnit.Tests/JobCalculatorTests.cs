﻿using System;
using System.Collections.Generic;
using Xunit;

namespace InnerWorkingsCodeAssignment.Tests
{
    public class JobCalculatorTests
    {
        [Fact]
        public void JobCalculator_GivenNullJobProperties_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new JobCalculator(null));
        }

        [Fact]
        public void Total_GivenNoItems_ReturnZero()
        {
            var properties = JobPropertiesForTest(new List<JobItem>());
            var actual = new JobCalculator(properties).Total;

            Assert.Equal(0m, actual);
        }

        [Fact]
        public void Total_GivenNonExemptItemAndNoExtraMargin_Return118()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100m, false)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, false)).Total;

            Assert.Equal(118m, actual);
        }

        [Fact]
        public void Total_GivenNonExemptItemAndExtraMargin_Return124()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100m, false)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, true)).Total;

            Assert.Equal(123m, actual);
        }

        [Fact]
        public void Total_GivenExemptItemAndNoExtraMargin_Return111()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100m, true)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, false)).Total;

            Assert.Equal(111m, actual);
        }

        [Fact]
        public void Total_GivenExemptItemAndExtraMargin_ReturnTotalOf116()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100m, true)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, true)).Total;

            Assert.Equal(116m, actual);
        }

        [Fact]
        public void Total_GivenAnItem_CalculateTotalToNearestEvenCent()
        {
            var items = new List<JobItem>
            {
                new JobItem(string.Empty, 100.04m, false)
            };
            var actual = new JobCalculator(JobPropertiesForTest(items, true)).Total;

            Assert.Equal(123.04m, actual);
        }

        [Fact]
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

            Assert.Equal(Expected, actual);
        }

        #region Test helpers

        private JobProperties JobPropertiesForTest(List<JobItem> list, bool extraMargin = false)
        {
            return new JobProperties(list, 0.07m, 0.11m, extraMargin, 0.05m);
        }

        #endregion Test helpers
    }
}