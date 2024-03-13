using Funcer.Tests.Common;

namespace Funcer.Tests.Ensure;

using Ensure = Funcer.Ensure;

public class HasValueTests
{
    [Fact]
    public void Ensure_HasValue_Success()
    {
        const string testObject = "test Value";
        var result = Ensure.HasValue(testObject, Values.TestError);

        result.ShouldBeSuccess(testObject);
    }
    
    [Fact]
    public void Ensure_HasValue_Failure()
    {
        string? testObject = null;
        var result = Ensure.HasValue(testObject, Values.TestError);

        result.ShouldBeFailure();
    }
}