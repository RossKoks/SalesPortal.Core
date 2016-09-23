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
    }
}
