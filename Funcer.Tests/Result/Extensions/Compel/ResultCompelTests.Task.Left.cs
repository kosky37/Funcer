using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Compel;

public class ResultCompelTests_Task_Left
{
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => TestResult.Async.Failure.Compel(_ => new ArgumentException()));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        await TestResult.Async.Success.Compel(_ => new ArgumentException());
    }
}