using System;
using Xunit;

namespace ElectricityManagement.Tests
{
    public class ResultTests
    {
        [Fact]
        public void OkResult()
        {
            var result = Result<int>.Ok(1000);
            Assert.Equal<int>(1000, result.Value);
        }

        [Fact]
        public void ErrorResult()
        {
            var result = Result<string>.Error("This is a test Error Message.");
            Assert.Equal("This is a test Error Message.", result.Value);
        }
    }


    public class Result<T>
    {
	    public T Value { get; set; }	    
        public static Result<T> Ok(T value) => new Result<T>(value);
        public static Result<string> Error(string errorMessage) =>new Result<string>(errorMessage);

        public Result()
        {

        }
	    public Result(T value)
	    {
		    this.Value = value;
	    }
    }

}
