using Funcer.Tests.Common;

namespace Funcer.Tests.Create;

public class ResultTests_Create
{
    [Fact]
    public void Should_Create_Success()
    {
        var result = Result.Create(true, Values.TestError);

        result.ShouldBeSuccess();
    }
    
    [Fact]
    public void Should_Create_Success_From_Function()
    {
        var result = Result.Create(Functions.Returns.True, Values.TestError);

        result.ShouldBeSuccess();
    }
    
    [Fact]
    public void Should_Create_Failure()
    {
        var result = Result.Create(false, Values.TestError);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public void Should_Create_Failure_From_Function()
    {
        var result = Result.Create(Functions.Returns.False, Values.TestError);

        result.ShouldBeFailure();
    }
}