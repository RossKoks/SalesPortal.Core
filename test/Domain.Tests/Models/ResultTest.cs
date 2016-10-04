using Xunit;
using FluentAssertions;
using SalesPortal.Core.Models;
using Domain.Enums;
using System.Collections.Generic;
using System;

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
        public void Test_Wrap_Value_With_Func_When_Value_Is_Empty_String()
        {
            string value = string.Empty;
            var testResult = Result<int>.Wrap(value, x => !string.IsNullOrEmpty(x));
            testResult.Should().NotBeNull();
            testResult.IsSuccess.Should().BeFalse();
            testResult.Value.Should().Be(value);
        }

        [Fact]
        public void Test_Wrap_Value_With_Func()
        {
            int value = 22;
            var testResult = Result<int>.Wrap(value, x => x == 22);
            testResult.Should().NotBeNull();
            testResult.IsSuccess.Should().BeTrue();
            testResult.Value.Should().Be(value);
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
            testResult.Value.Should().Be(value);
        }

        [Fact]
        public void Test_Error_Wrap_Value_Type()
        {
            var testResult = Result<int>.Error("Error");
            testResult.Should().NotBeNull();
            testResult.IsSuccess.Should().BeFalse();
            testResult.Value.Should().Be(default(int));
        }

        [Fact]
        public void Test_Error_Wrap_Reference_Type()
        {
            var testResult = Result<string>.Error("Error");
            testResult.Should().NotBeNull();
            testResult.IsSuccess.Should().BeFalse();
            testResult.Value.Should().Be(default(string));
        }

        /* DML Result */

        [Fact]
        public void Test_Dml_Failed()
        {
            var value = Tuple.Create(item1: default(string), item2: "FAILED");
            var testResult = Result<string, DMLResultType>.WrapDml(value);
            testResult.Should().NotBeNull();
            testResult.IsSuccess.Should().BeFalse();
            testResult.Value.Should().Be(default(string));
            testResult.ResultType.Should().NotBeNull();
            testResult.ResultType.Should().Be(DMLResultType.FAILED);
        }

        [Fact]
        public void Test_Dml_Succeed()
        {
            var value =  Tuple.Create(item1: 1, item2: "SUCCEED");
            var testResult = Result<int, DMLResultType>.WrapDml(value);
            testResult.Should().NotBeNull();
            testResult.IsSuccess.Should().BeTrue();
            testResult.Value.Should().Be(1);
            testResult.ResultType.Should().NotBeNull();
            testResult.ResultType.Should().Be(DMLResultType.SUCCEED);

        }
    }
}
