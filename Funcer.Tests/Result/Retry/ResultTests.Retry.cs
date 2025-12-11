using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Retry;

using Result = Funcer.Result;

public class ResultTests_Retry
{
    private const string RetryableErrorType = "RetryableError";
    private const string NonRetryableErrorType = "NonRetryableError";
    
    [Fact]
    public void Should_Return_Success_On_First_Attempt()
    {
        var attemptCount = 0;
        var result = Result.Retry(
            attemptNumber =>
            {
                attemptCount++;
                return Result.Success();
            },
            RetryableErrorType,
            maxTries: 3
        );

        result.ShouldBeSuccess();
        attemptCount.Should().Be(1);
    }
    
    [Fact]
    public void Should_Return_Success_After_Retries()
    {
        var attemptCount = 0;
        var result = Result.Retry(
            attemptNumber =>
            {
                attemptCount++;
                if (attemptNumber < 3)
                {
                    return Result.Failure(new ErrorMessage(RetryableErrorType, "Retryable error"));
                }
                return Result.Success();
            },
            RetryableErrorType,
            maxTries: 5
        );

        result.ShouldBeSuccess();
        attemptCount.Should().Be(3);
    }
    
    [Fact]
    public void Should_Return_Immediately_When_Error_Type_Differs()
    {
        var attemptCount = 0;
        var result = Result.Retry(
            attemptNumber =>
            {
                attemptCount++;
                return Result.Failure(new ErrorMessage(NonRetryableErrorType, "Different error type"));
            },
            RetryableErrorType,
            maxTries: 5
        );

        result.IsFailure.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().Type.Should().Be(NonRetryableErrorType);
        result.Errors.First().Message.Should().Be("Different error type");
        attemptCount.Should().Be(1);
    }
    
    [Fact]
    public void Should_Return_Failure_After_Max_Tries_Exhausted()
    {
        var attemptCount = 0;
        var result = Result.Retry(
            attemptNumber =>
            {
                attemptCount++;
                return Result.Failure(new ErrorMessage(RetryableErrorType, "Retryable error"));
            },
            RetryableErrorType,
            maxTries: 3
        );

        result.IsFailure.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().Type.Should().Be(RetryableErrorType);
        result.Errors.First().Message.Should().Be("Retryable error");
        attemptCount.Should().Be(3);
    }
    
    [Fact]
    public void Should_Return_Success_On_Last_Attempt()
    {
        var attemptCount = 0;
        var result = Result.Retry(
            attemptNumber =>
            {
                attemptCount++;
                if (attemptNumber < 3)
                {
                    return Result.Failure(new ErrorMessage(RetryableErrorType, "Retryable error"));
                }
                return Result.Success();
            },
            RetryableErrorType,
            maxTries: 3
        );

        result.ShouldBeSuccess();
        attemptCount.Should().Be(3);
    }
}
