using Funcer.Tests.Common;

namespace Funcer.Tests.Create;

public class ValueResultTests_Create
{
    [Fact]
    public void Should_Create_Success()
    {
        var result = Result.Create(Functions.Returns.True, Values.Alpha1, Values.TestError);

        result.ShouldBeSuccess(Values.Alpha1);
    }
    
    [Fact]
    public void Should_Create_Failure()
    {
        var result = Result.Create(Functions.Returns.False, Values.Alpha1, Values.TestError);

        result.ShouldBeFailure();
    }
}