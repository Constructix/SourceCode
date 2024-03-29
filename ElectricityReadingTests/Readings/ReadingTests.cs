﻿using System;
using Constructix.Home.Electricity;
using Xunit;

namespace ElectricityReadingTests.Readings
{
    public class ReadingTests
    {

        private Reading firstReading;
        private Reading latestReading;
        public ReadingTests()
        {
            firstReading = new Reading(1000, DateTime.Parse("01/10/2017"));
            latestReading = new Reading(1030, DateTime.Parse("02/10/2017"));
        }
        [Fact]
        public void InstanceNotNull()
        {
            Assert.NotNull(firstReading);
        }

        [Fact]
        public void LatestReadingValueIsExpected()
        {
            int expectedValue = 1030;

            Assert.True(expectedValue.Equals(latestReading.Value));
        }
    }
}