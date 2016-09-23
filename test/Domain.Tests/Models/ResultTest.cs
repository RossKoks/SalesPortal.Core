using Xunit;
using FluentAssertions;
using SalesPortal.Core.Models;

namespace Domain.Tests.Models
{
    public class ResultTest
    {
        [Fact]
        public void Test_Wrap_When_Value_Is_Null()
        {
            string value = null;
            var testResult = Result<string>.Wrap(value);
            testResult.Should().NotBeNull();
            testResult.IsSuccess.Should().BeFalse();
            testResult.Value.Should().BeNull();
        }

        [Fact]
        public void Test_Wrap_When_Value_Is_Not_Null()
        {
            string value = "test";
            var testResult = Result<string>.Wrap(value);
            testResult.Should().NotBeNull();
            testResult.IsSuccess.Should().BeTrue();
            testResult.Value.Should().NotBeNull();
        }

        [Fact]
        public void Test_Wrap_Value()
        {
            int value = 2;
            var testResult = Result<int>.WrapValue(value);
            testResult.Should().NotBeNull();
            testResult.IsSuccess.Should().BeTrue();
            testResult.Value.Should().Equals(value);
        }
    }
}