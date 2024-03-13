using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Compel;

public class ResultCompelTests_Task
{
    [Fact]
    public async Task Should_Throw_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<FailureResultException>(() => TestResult.Async.Failure.Compel());
    }
    
    [Fact]
    public async Task Should_Not_Throw_When_Result_Is_Success()
    {
        await TestResult.Async.Success.Compel();
    }
    
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => TestResult.Async.Failure.Compel(_ => AsyncFunc.Returns.ArgumentException));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        await TestResult.Async.Success.Compel(_ => AsyncFunc.Returns.ArgumentException);
    }
} 