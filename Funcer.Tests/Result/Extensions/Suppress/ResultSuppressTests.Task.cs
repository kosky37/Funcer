using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Suppress;

using Result = Funcer.Result;

public class ResultSuppressTests_Task
{
    [Fact]
    public async Task Failure_Suppress_Success()
    {
        (await TestResult.Async.Failure
            .Suppress(Values.TestError.Type))
            .ShouldBeSuccess();
    }
    
    [Fact]
    public async Task Failure_Suppress_Multiple_SameType_Success()
    {
        var resultTask = Task.FromResult(Result.Combine(TestResult.Failure, TestResult.Failure));
        
        (await resultTask
            .Suppress(Values.TestError.Type))
            .ShouldBeSuccess();
    }
    
    [Fact]
    public async Task Failure_Suppress_OtherType_Failure()
    {
        (await TestResult.Async.Failure
            .Suppress("Wrong error"))
            .ShouldBeFailure();
    }
    
    [Fact]
    public async Task Failure_Suppress_OneOfErrors_Failure()
    {
        var otherError = new ErrorMessage("Other type", "Some message");
        var resultTask = Task.FromResult(Result.Combine(TestResult.Failure, Result.Failure(otherError)));
        
        (await resultTask
            .Suppress(otherError.Type))
            .ShouldBeFailure();
    }
}