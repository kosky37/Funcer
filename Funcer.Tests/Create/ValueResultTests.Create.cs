using Funcer.Tests.Common;

namespace Funcer.Tests.Create;

public class ValueResultTests_Create
{
    [Fact]
    public void Should_Create_Success()
    {
        var result = Result.Create(true, Values.Alpha1, Values.TestError);

        result.ShouldBeSuccess(Values.Alpha1);
    }
    
    [Fact]
    public void Should_Create_Success_From_Function()
    {
        var result = Result.Create(Functions.Returns.True, Values.Alpha1, Values.TestError);

        result.ShouldBeSuccess(Values.Alpha1);
    }
    
    [Fact]
    public void Should_Create_Failure()
    {
        var result = Result.Create(false, Values.Alpha1, Values.TestError);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public void Should_Create_Failure_From_Function()
    {
        var result = Result.Create(Functions.Returns.False, Values.Alpha1, Values.TestError);

        result.ShouldBeFailure();
    }
}