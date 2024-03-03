using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Suppress;

public class ResultSuppressTests_Task
{
    [Fact]
    public async Task Failure_Suppress_Success()
    {
        (await Results.Tasks.Failure.Nothing
            .Suppress(Values.TestError.Type))
            .ShouldBeSuccess();
    }
    
    [Fact]
    public async Task Failure_Suppress_Multiple_SameType_Success()
    {
        var resultTask = Task.FromResult(Result.Combine(Results.Failure.Nothing, Results.Failure.Nothing));
        
        (await resultTask
            .Suppress(Values.TestError.Type))
            .ShouldBeSuccess();
    }
    
    [Fact]
    public async Task Failure_Suppress_OtherType_Failure()
    {
        (await Results.Tasks.Failure.Nothing
            .Suppress("Wrong error"))
            .ShouldBeFailure();
    }
    
    [Fact]
    public async Task Failure_Suppress_OneOfErrors_Failure()
    {
        var otherError = new ErrorMessage("Other type", "Some message");
        var resultTask = Task.FromResult(Result.Combine(Results.Failure.Nothing, Result.Failure(otherError)));
        
        (await resultTask
            .Suppress(otherError.Type))
            .ShouldBeFailure();
    }
}