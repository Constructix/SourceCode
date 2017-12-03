﻿using System;
using Constructix.Home.Electricity;
using Constructix.Home.Electricity.Validators;
using Xunit;

namespace ElectricityReadingTests.Readings
{

    public class ReadingValidatorTests
    {
        private Reading firstReading;
        private Reading latestReading;

        [Fact]
        public void ReadingValidatorReturnsTrueAsExpected()
        {
            firstReading= new Reading(1000, DateTime.Parse("01/11/2017"));
            latestReading = new Reading(1030, DateTime.Parse("02/11/2017"));

            var expectedValue = true;
            var validator =  new ReadingValidator();
            Assert.True(validator.IsValid(firstReading, latestReading));
        }

        [Fact]
        public void ReadingValueCompare()
        {
            firstReading = new Reading(1000, DateTime.Parse("01/11/2017"));
            latestReading = new Reading(1030, DateTime.Parse("02/11/2017"));
            ReadingComparer comparer = new ReadingComparer();

            int result = comparer.Compare(firstReading, latestReading);
            int expectedResult = -1;
            Assert.Equal(result,  expectedResult );
        }
    }
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