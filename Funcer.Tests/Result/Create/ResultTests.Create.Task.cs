using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Create;

using Result = Funcer.Result;

public class ResultTests_Create_Task
{
    [Fact]
    public async Task Should_Create_Failure_From_Task()
    {
        var result = await Result.Create(AsyncFunc.Returns.False, TestValues.Error);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public async Task Should_Create_Success_From_Task()
    {
        var result = await Result.Create(AsyncFunc.Returns.True, TestValues.Error);

        result.ShouldBeSuccess();
    }
}