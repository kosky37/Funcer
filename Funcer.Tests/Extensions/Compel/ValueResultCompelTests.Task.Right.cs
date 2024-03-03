using FluentAssertions;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Compel;

public class ValueResultCompelTests_Task_Right
{
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => Results.Failure.Alpha.Compel(_ => Tasks.Returns.ArgumentException));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        var result = await Results.Success.Alpha1.Compel(_ => Tasks.Returns.ArgumentException);
        
        result.Should().Be(Values.Alpha1);
    }
}