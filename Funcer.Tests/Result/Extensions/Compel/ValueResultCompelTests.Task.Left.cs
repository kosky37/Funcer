using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Compel;

public class ValueResultCompelTests_Task_Left
{
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => TestResult.Alpha.Async.Failure.Compel(_ => new ArgumentException()));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        var result = await TestResult.Alpha.Async.Success.V1.Compel(_ => new ArgumentException());
        
        result.Should().Be(TestValues.Alpha1);
    }
}