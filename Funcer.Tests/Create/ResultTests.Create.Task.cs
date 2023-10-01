using Funcer.Tests.Common;

namespace Funcer.Tests.Create;

public class ResultTests_Create_Task
{
    [Fact]
    public async Task Should_Create_Failure_From_Task()
    {
        var result = await Result.Create(Tasks.Returns.False, Values.TestError);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public async Task Should_Create_Success_From_Task()
    {
        var result = await Result.Create(Tasks.Returns.True, Values.TestError);

        result.ShouldBeSuccess();
    }
}