using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Compel;

public class ResultCompelTests
{
    [Fact]
    public void Should_Throw_When_Result_Is_Failure()
    {
        Assert.Throws<FailureResultException>(() => Results.Failure.Nothing.Compel());
    }
    
    [Fact]
    public void Should_Not_Throw_When_Result_Is_Success()
    {
        Results.Success.Nothing.Compel();
    }
    
    [Fact]
    public void Should_Throw_Custom_When_Result_Is_Failure()
    {
        Assert.Throws<ArgumentException>(() => Results.Failure.Nothing.Compel(_ => new ArgumentException()));
    }
    
    [Fact]
    public void Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        Results.Success.Nothing.Compel(_ => new ArgumentException());
    }
}