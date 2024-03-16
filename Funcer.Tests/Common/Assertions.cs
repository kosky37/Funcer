using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer.Tests.Common;

using Result = Funcer.Result;

public static class Assertions
{
    public static readonly Action<Result> ResultSuccess = result => { result.ShouldBeSuccess(); };
    
    public static readonly Action<Result, IResultMessage> ResultSuccessWithWarning = (result, message) =>
    {
        result
            .ShouldBeSuccess()
            .ShouldHaveWarning(message);
    };
    
    public static readonly Action<Result, IResultMessage> ResultSuccessWithoutWarnings = (result, _) =>
    {
        result
            .ShouldBeSuccess()
            .ShouldNotHaveWarnings();
    };
    
    public static readonly Action<Result> ResultFailure = result => { result.ShouldBeFailure(); };
    
    public static readonly Action<Result, IResultMessage> ResultFailureWithoutWarnings = (result, _) =>
    {
        result
            .ShouldBeFailure()
            .ShouldNotHaveWarnings();
    };
    

    public static readonly Action<Result<Types.Alpha>, Types.Alpha> ValueResultSuccess = (result, expectedValue) =>
    {
        result.ShouldBeSuccess(expectedValue);
    };
    
    public static readonly Action<Result<Types.Alpha>, Types.Alpha, IResultMessage> ValueResultSuccessWithWarning = (result, expectedValue, message) =>
    {
        result
            .ShouldBeSuccess(expectedValue)
            .ShouldHaveWarning(message);
    };
    
    public static readonly Action<Result<Types.Alpha>, Types.Alpha, IResultMessage> ValueResultSuccessWithoutWarnings = (result, expectedValue, _) =>
    {
        result
            .ShouldBeSuccess(expectedValue)
            .ShouldNotHaveWarnings();
    };

    public static readonly Action<Result<Types.Alpha>, Types.Alpha> ValueResultFailure = (result, _) =>
    {
        result.ShouldBeFailure();
    };
    
    public static readonly Action<Result<Types.Alpha>, Types.Alpha, IResultMessage> ValueResultFailureWithoutWarnings = (result, _, _) =>
    {
        result
            .ShouldBeFailure()
            .ShouldNotHaveWarnings();
    };

    public static IResult ShouldBeSuccess(this IResult result)
    {
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Errors.Should().BeEmpty();
        
        return result;
    }

    public static Result<TValue> ShouldBeSuccess<TValue>(this Result<TValue> result, TValue expectedValue)
    {
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Errors.Should().BeEmpty();
        result.Value.Should().Be(expectedValue);
        
        return result;
    }

    public static IResult ShouldBeFailure(this IResult result)
    {
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().Message.Should().Be(TestValues.Error.Message);
        result.Errors.First().Type.Should().Be(TestValues.Error.Type);
        
        return result;
    }

    public static Result<TValue> ShouldBeFailure<TValue>(this Result<TValue> result)
    {
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().Message.Should().Be(TestValues.Error.Message);
        result.Errors.First().Type.Should().Be(TestValues.Error.Type);
        Assert.Throws<FailureResultException>(() => result.Value);

        return result;
    }
    
    public static IResult ShouldHaveWarning(this IResult result, IResultMessage resultMessage)
    {
        result.Warnings.Should().HaveCount(1);
        result.Warnings.First().Message.Should().Be(resultMessage.Message);
        result.Warnings.First().Type.Should().Be(resultMessage.Type);

        return result;
    }
    
    public static IResult ShouldNotHaveWarnings(this IResult result)
    {
        result.Warnings.Should().HaveCount(0);

        return result;
    }
}