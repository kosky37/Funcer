using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Compel;

public class ResultCompelTests
{
    [Fact]
    public void Should_Throw_When_Result_Is_Failure()
    {
        Assert.Throws<FailureResultException>(() => TestResult.Failure.Compel());
    }
    
    [Fact]
    public void Should_Not_Throw_When_Result_Is_Success()
    {
        TestResult.Success.Compel();
    }
    
    [Fact]
    public void Should_Throw_Custom_When_Result_Is_Failure()
    {
        Assert.Throws<ArgumentException>(() => TestResult.Failure.Compel(_ => new ArgumentException()));
    }
    
    [Fact]
    public void Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        TestResult.Success.Compel(_ => new ArgumentException());
    }
}