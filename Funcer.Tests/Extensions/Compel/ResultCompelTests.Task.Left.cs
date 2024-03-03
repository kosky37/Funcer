using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Compel;

public class ResultCompelTests_Task_Left
{
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => Results.Tasks.Failure.Nothing.Compel(_ => new ArgumentException()));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        await Results.Tasks.Success.Nothing.Compel(_ => new ArgumentException());
    }
}