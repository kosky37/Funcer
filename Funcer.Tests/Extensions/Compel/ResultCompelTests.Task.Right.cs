using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Compel;

public class ResultCompelTests_Task_Right
{
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => Results.Failure.Nothing.Compel(_ => Tasks.Returns.ArgumentException));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        await Results.Success.Nothing.Compel(_ => Tasks.Returns.ArgumentException);
    }
}