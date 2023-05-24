using Funcer.Tests.Common;

namespace Funcer.Tests.Create;

public partial class ResultTests
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
        var result = Result.Create(FunctionsOld.True.WithDefault, Values.TestError);

        result.ShouldBeSuccess();
    }
    
    [Fact]
    public async Task Should_Create_Success_From_Task()
    {
        var result = await Result.Create(FunctionsOld.True.WithTask, Values.TestError);

        result.ShouldBeSuccess();
    }
    
    [Fact]
    public async ValueTask Should_Create_Success_From_ValueTask()
    {
        var result = await Result.Create(FunctionsOld.True.WithValueTask, Values.TestError);

        result.ShouldBeSuccess();
    }
}