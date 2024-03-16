using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Compel;

public class ValueResultCompelTests_Task_Right
{
    [Fact]
    public async Task Should_Throw_Custom_When_Result_Is_Failure()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => TestResult.Alpha.Failure.Compel(_ => AsyncFunc.Returns.ArgumentException));
    }
    
    [Fact]
    public async Task Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        var result = await TestResult.Alpha.Success.V1.Compel(_ => AsyncFunc.Returns.ArgumentException);
        
        result.Should().Be(TestValues.Alpha1);
    }
}