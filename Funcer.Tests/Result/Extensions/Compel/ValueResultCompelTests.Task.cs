using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Compel;

public class ValueResultCompelTests_Task
{
    [Fact]
    public async Task Should_Throw_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<FailureResultException>(() => TestResult.Alpha.Async.Failure.Compel());
    }
    
    [Fact]
    public async Task Should_Not_Throw_When_Result_Is_Success()
    {
        var result =  await TestResult.Alpha.Async.Success.V1.Compel();

        result.Should().Be(Values.Alpha1);
    }
    
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => TestResult.Alpha.Async.Failure.Compel(_ => Tasks.Returns.ArgumentException));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        var result = await TestResult.Alpha.Async.Success.V1.Compel(_ => Tasks.Returns.ArgumentException);
        
        result.Should().Be(Values.Alpha1);
    }
}