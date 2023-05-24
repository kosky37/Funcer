using FluentAssertions;

namespace Funcer.Tests.Common;

public static class Assertions
{
    public static readonly Action<Result> ResultSuccess = result =>
    {
        result.ShouldBeSuccess();
    };
    
    public static readonly Action<Result> ResultFailure = result =>
    {
        result.ShouldBeFailure();
    };

    public static readonly Action<Result<Types.Alpha>, Types.Alpha> ValueResultSuccess = (result, expectedValue) =>
    {
        result.ShouldBeSuccess(expectedValue);
    };

    public static readonly Action<Result<Types.Alpha>, Types.Alpha> ValueResultFailure = (result, _) =>
    {
        result.ShouldBeFailure();
    };

    public static void ShouldBeSuccess(this Result result)
    {
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Errors.Should().BeEmpty();
    }
    
    public static void ShouldBeSuccess<TValue>(this Result<TValue> result, TValue expectedValue)
    {
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Errors.Should().BeEmpty();
        result.Value.Should().Be(expectedValue);
    }
    
    public static void ShouldBeFailure(this Result result)
    {
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().Message.Should().Be(Values.TestError.Message);
        result.Errors.First().Type.Should().Be(Values.TestError.Type);
    }
    
    public static void ShouldBeFailure<TValue>(this Result<TValue> result)
    {
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().Message.Should().Be(Values.TestError.Message);
        result.Errors.First().Type.Should().Be(Values.TestError.Type);
        result.Value.Should().BeNull();
    }
}