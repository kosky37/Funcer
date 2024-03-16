using Funcer.Exceptions;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Compel;

public class ValueResultCompelTests
{
    [Fact]
    public void Should_Throw_When_Result_Is_Failure()
    {
        Assert.Throws<FailureResultException>(() => TestResult.Alpha.Failure.Compel());
    }
    
    [Fact]
    public void Should_Not_Throw_When_Result_Is_Success()
    {
        var result = TestResult.Alpha.Success.V1.Compel();

        result.Should().Be(TestValues.Alpha1);
    }
    
    [Fact]
    public void Should_Throw_Custom_When_Result_Is_Failure()
    {
        Assert.Throws<ArgumentException>(() => TestResult.Alpha.Failure.Compel(_ => new ArgumentException()));
    }
    
    [Fact]
    public void Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        var result = TestResult.Alpha.Success.V1.Compel(_ => new ArgumentException());
        
        result.Should().Be(TestValues.Alpha1);
    }
}