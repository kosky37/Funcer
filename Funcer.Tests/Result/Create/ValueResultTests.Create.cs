using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Create;

using Result = Funcer.Result;

public class ValueResultTests_Create
{
    [Fact]
    public void Should_Create_Success()
    {
        var result = Result.Create(true, TestValues.Alpha1, TestValues.Error);

        result.ShouldBeSuccess(TestValues.Alpha1);
    }
    
    [Fact]
    public void Should_Create_Success_From_Function()
    {
        var result = Result.Create(TestFunc.Returns.True, TestValues.Alpha1, TestValues.Error);

        result.ShouldBeSuccess(TestValues.Alpha1);
    }
    
    [Fact]
    public void Should_Create_Failure()
    {
        var result = Result.Create(false, TestValues.Alpha1, TestValues.Error);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public void Should_Create_Failure_From_Function()
    {
        var result = Result.Create(TestFunc.Returns.False, TestValues.Alpha1, TestValues.Error);

        result.ShouldBeFailure();
    }
}