using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Create;

using Result = Funcer.Result;

public class ResultTests_Create
{
    [Fact]
    public void Should_Create_Success()
    {
        var result = Result.Create(true, TestValues.Error);

        result.ShouldBeSuccess();
    }
    
    [Fact]
    public void Should_Create_Success_From_Function()
    {
        var result = Result.Create(TestFunc.Returns.True, TestValues.Error);

        result.ShouldBeSuccess();
    }
    
    [Fact]
    public void Should_Create_Failure()
    {
        var result = Result.Create(false, TestValues.Error);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public void Should_Create_Failure_From_Function()
    {
        var result = Result.Create(TestFunc.Returns.False, TestValues.Error);

        result.ShouldBeFailure();
    }
}