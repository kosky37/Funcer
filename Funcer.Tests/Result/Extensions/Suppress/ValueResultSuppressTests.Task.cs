using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Suppress;

using Result = Funcer.Result;

public class ValueResultSuppressTests_Task
{
    [Fact]
    public async Task Failure_Suppress_Success()
    {
        (await TestResult.Alpha.Async.Failure
            .Suppress(TestValues.Error.Type))
            .ShouldBeSuccess();
    }
    
    [Fact]
    public async Task Failure_Suppress_Multiple_SameType_Success()
    {
        var resultTask = Task.FromResult(Result.Combine(TestResult.Alpha.Failure, TestResult.Failure));
        
        (await resultTask
            .Suppress(TestValues.Error.Type))
            .ShouldBeSuccess();
    }
    
    [Fact]
    public async Task Failure_Suppress_OtherType_Failure()
    {
        (await TestResult.Alpha.Async.Failure
            .Suppress("Wrong error"))
            .ShouldBeFailure();
    }
    
    [Fact]
    public async Task Failure_Suppress_OneOfErrors_Failure()
    {
        var otherError = new ErrorMessage("Other type", "Some message");
        var resultTask = Task.FromResult(Result.Combine(TestResult.Alpha.Failure, Result.Failure(otherError)));
        
        (await resultTask
            .Suppress(otherError.Type))
            .ShouldBeFailure();
    }
}