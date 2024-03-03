using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Compel;

public class ResultCompelTests_Task
{
    [Fact]
    public async Task Should_Throw_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<FailureResultException>(() => Results.Tasks.Failure.Nothing.Compel());
    }
    
    [Fact]
    public async Task Should_Not_Throw_When_Result_Is_Success()
    {
        await Results.Tasks.Success.Nothing.Compel();
    }
    
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => Results.Tasks.Failure.Nothing.Compel(_ => Tasks.Returns.ArgumentException));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        await Results.Tasks.Success.Nothing.Compel(_ => Tasks.Returns.ArgumentException);
    }
} 