using Funcer.Tests.Common;

namespace Funcer.Tests;

public class EnsureTests_HasValue
{
    [Fact]
    public void Should_Ensure_HasValue_Success()
    {
        var testObject = "test Value";
        var result = Ensure.HasValue(testObject, Values.TestError);

        result.ShouldBeSuccess(testObject);
    }
    
    [Fact]
    public void Should_Ensure_HasValue_Failure()
    {
        string? testObject = null;
        var result = Ensure.HasValue(testObject, Values.TestError);

        result.ShouldBeFailure();
    }
}