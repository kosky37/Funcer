using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Suppress;

using Result = Funcer.Result;

public class ResultSuppressTests
{
    [Fact]
    public void Failure_Suppress_Success()
    {
        TestResult.Failure
            .Suppress(TestValues.Error.Type)
            .ShouldBeSuccess();
    }
    
    [Fact]
    public void Failure_Suppress_Multiple_SameType_Success()
    {
        var result = Result.Combine(TestResult.Failure, TestResult.Failure);
        
        result
            .Suppress(TestValues.Error.Type)
            .ShouldBeSuccess();
    }
    
    [Fact]
    public void Failure_Suppress_OtherType_Failure()
    {
        TestResult.Failure
            .Suppress("Wrong error")
            .ShouldBeFailure();
    }
    
    [Fact]
    public void Failure_Suppress_OneOfErrors_Failure()
    {
        var otherError = new ErrorMessage("Other type", "Some message");
        var result = Result.Combine(TestResult.Failure, Result.Failure(otherError));
        
        result
            .Suppress(otherError.Type)
            .ShouldBeFailure();
    }
}