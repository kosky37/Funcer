using FluentAssertions;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Compel;

public class ValueResultCompelTests
{
    [Fact]
    public void Should_Throw_When_Result_Is_Failure()
    {
        Assert.Throws<FailureResultException>(() => Results.Failure.Alpha.Compel());
    }
    
    [Fact]
    public void Should_Not_Throw_When_Result_Is_Success()
    {
        var result = Results.Success.Alpha1.Compel();

        result.Should().Be(Values.Alpha1);
    }
    
    [Fact]
    public void Should_Throw_Custom_When_Result_Is_Failure()
    {
        Assert.Throws<ArgumentException>(() => Results.Failure.Alpha.Compel(_ => new ArgumentException()));
    }
    
    [Fact]
    public void Should_Not_Throw_Custom_When_Result_Is_Success()
    {
        var result = Results.Success.Alpha1.Compel(_ => new ArgumentException());
        
        result.Should().Be(Values.Alpha1);
    }
}