using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Suppress;

public class ValueResultSuppressTests
{
    [Fact]
    public void Failure_Suppress_Success()
    {
        Results.Failure.Alpha
            .Suppress(Values.TestError.Type)
            .ShouldBeSuccess();
    }
    
    [Fact]
    public void Failure_Suppress_Multiple_SameType_Success()
    {
        var result = Result.Combine(Results.Failure.Alpha, Results.Failure.Nothing);
        
        result
            .Suppress(Values.TestError.Type)
            .ShouldBeSuccess();
    }
    
    [Fact]
    public void Failure_Suppress_OtherType_Failure()
    {
        Results.Failure.Alpha
            .Suppress("Wrong error")
            .ShouldBeFailure();
    }
    
    [Fact]
    public void Failure_Suppress_OneOfErrors_Failure()
    {
        var otherError = new ErrorMessage("Other type", "Some message");
        var result = Result.Combine(Results.Failure.Alpha, Result.Failure(otherError));
        
        result
            .Suppress(otherError.Type)
            .ShouldBeFailure();
    }
}