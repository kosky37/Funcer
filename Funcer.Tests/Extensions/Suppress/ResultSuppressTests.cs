using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Suppress;

public class ResultSuppressTests
{
    [Fact]
    public void Failure_Suppress_Success()
    {
        Results.Failure.Nothing
            .Suppress(Values.TestError.Type)
            .ShouldBeSuccess();
    }
    
    [Fact]
    public void Failure_Suppress_Multiple_SameType_Success()
    {
        var result = Result.Combine(Results.Failure.Nothing, Results.Failure.Nothing);
        
        result
            .Suppress(Values.TestError.Type)
            .ShouldBeSuccess();
    }
    
    [Fact]
    public void Failure_Suppress_OtherType_Failure()
    {
        Results.Failure.Nothing
            .Suppress("Wrong error")
            .ShouldBeFailure();
    }
    
    [Fact]
    public void Failure_Suppress_OneOfErrors_Failure()
    {
        var otherError = new ErrorMessage("Other type", "Some message");
        var result = Result.Combine(Results.Failure.Nothing, Result.Failure(otherError));
        
        result
            .Suppress(otherError.Type)
            .ShouldBeFailure();
    }
}