using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Suppress;

using Result = Funcer.Result;

public class ValueResultSuppressTests
{
    [Fact]
    public void Failure_Suppress_Success()
    {
        TestResult.Alpha.Failure
            .Suppress(Values.TestError.Type)
            .ShouldBeSuccess();
    }
    
    [Fact]
    public void Failure_Suppress_Multiple_SameType_Success()
    {
        var result = Result.Combine(TestResult.Alpha.Failure, TestResult.Failure);
        
        result
            .Suppress(Values.TestError.Type)
            .ShouldBeSuccess();
    }
    
    [Fact]
    public void Failure_Suppress_OtherType_Failure()
    {
        TestResult.Alpha.Failure
            .Suppress("Wrong error")
            .ShouldBeFailure();
    }
    
    [Fact]
    public void Failure_Suppress_OneOfErrors_Failure()
    {
        var otherError = new ErrorMessage("Other type", "Some message");
        var result = Result.Combine(TestResult.Alpha.Failure, Result.Failure(otherError));
        
        result
            .Suppress(otherError.Type)
            .ShouldBeFailure();
    }
}