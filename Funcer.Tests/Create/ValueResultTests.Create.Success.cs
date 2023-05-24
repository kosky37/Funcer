using Funcer.Tests.Common;

namespace Funcer.Tests.Create;

public partial class ValueResultTests
{
    [Fact]
    public void Should_Create_Success()
    {
        var result = Result.Create(FunctionsOld.True.WithDefault, Values.Alpha1, Values.TestError);

        result.ShouldBeSuccess(Values.Alpha1);
    }
    
    [Fact]
    public async Task Should_Create_Success_From_Task()
    {
        var result = await Result.Create(FunctionsOld.True.WithTask, Values.Alpha1, Values.TestError);

        result.ShouldBeSuccess(Values.Alpha1);
    }
    
    [Fact]
    public async ValueTask Should_Create_Success_From_ValueTask()
    {
        var result = await Result.Create(FunctionsOld.True.WithValueTask, Values.Alpha1, Values.TestError);

        result.ShouldBeSuccess(Values.Alpha1);
    }
}