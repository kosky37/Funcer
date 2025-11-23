using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.MapAll;

using Result = Funcer.Result;

public class MapAllTests
{
    [Fact]
    public void Should_MapAll_IEnumerable_Of_ValueResults()
    {
        var results = new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        };
        
        var mapped = results.MapAll(x => Result.Success(x.Value));

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
        mapped.Value.Should().Contain(true);
        mapped.Value.Should().Contain(false);
    }
    
    [Fact]
    public void Should_MapAll_IEnumerable_Of_ValueResults_And_Return_Failure_When_One_Fails()
    {
        var results = new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Failure
        };
        
        var mapped = results.MapAll(x => Result.Success(x.Value));

        mapped.ShouldBeFailure();
    }
    
    [Fact]
    public void Should_MapAll_IEnumerable_Of_ValueResults_With_Simple_Mapper()
    {
        var results = new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        };
        
        var mapped = results.MapAll(x => x.Value);

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
        mapped.Value.Should().Contain(true);
        mapped.Value.Should().Contain(false);
    }
}