using FluentAssertions;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Compel;

public class ValueResultCompelTests_Task
{
    [Fact]
    public async Task Should_Throw_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<FailureResultException>(() => Results.Tasks.Failure.Alpha.Compel());
    }
    
    [Fact]
    public async Task Should_Not_Throw_When_Result_Is_Success()
    {
        var result =  await Results.Tasks.Success.Alpha1.Compel();

        result.Should().Be(Values.Alpha1);
    }
    
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => Results.Tasks.Failure.Alpha.Compel(_ => Tasks.Returns.ArgumentException));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        var result = await Results.Tasks.Success.Alpha1.Compel(_ => Tasks.Returns.ArgumentException);
        
        result.Should().Be(Values.Alpha1);
    }
}