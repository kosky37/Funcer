using FluentAssertions;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Compel;

public class ValueResultCompelTests_Task_Left
{
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => Results.Tasks.Failure.Alpha.Compel(_ => new ArgumentException()));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        var result = await Results.Tasks.Success.Alpha1.Compel(_ => new ArgumentException());
        
        result.Should().Be(Values.Alpha1);
    }
}