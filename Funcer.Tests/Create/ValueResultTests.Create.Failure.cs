using Funcer.Tests.Common;

namespace Funcer.Tests.Create;

public partial class ValueResultTests
{
    [Fact]
    public void Should_Create_Failure()
    {
        var result = Result.Create(FunctionsOld.False.WithDefault, Values.Alpha1, Values.TestError);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public async Task Should_Create_Failure_From_Task()
    {
        var result = await Result.Create(FunctionsOld.False.WithTask, Values.Alpha1, Values.TestError);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public async ValueTask Should_Create_Failure_From_ValueTask()
    {
        var result = await Result.Create(FunctionsOld.False.WithValueTask, Values.Alpha1, Values.TestError);

        result.ShouldBeFailure();
    }
}