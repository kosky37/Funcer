using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Create;

using Result = Funcer.Result;

public class ValueResultTests_Create_Task
{
    [Fact]
    public async Task Should_Create_Success_From_Task()
    {
        var result = await Result.Create(AsyncFunc.Returns.True, Values.Alpha1, Values.TestError);

        result.ShouldBeSuccess(Values.Alpha1);
    }
    
    [Fact]
    public async Task Should_Create_Failure_From_Task()
    {
        var result = await Result.Create(AsyncFunc.Returns.False, Values.Alpha1, Values.TestError);

        result.ShouldBeFailure();
    }
}