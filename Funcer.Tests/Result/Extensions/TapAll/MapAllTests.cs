using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.TapAll;

using Result = Funcer.Result;

public class TapAllTests
{
    [Fact]
    public void Should_TapAll_IEnumerable_Of_ValueResults_With_Action()
    {
        var tappedValues = new List<bool>();
        var results = new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        };
        
        var result = results.TapAll(x => tappedValues.Add(x.Value));

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        tappedValues.Should().HaveCount(2);
        tappedValues.Should().Contain(true);
        tappedValues.Should().Contain(false);
    }
    
    [Fact]
    public void Should_TapAll_IEnumerable_Of_ValueResults_And_Return_Failure_When_One_Fails()
    {
        var tappedValues = new List<bool>();
        var results = new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Failure
        };
        
        var result = results.TapAll(x => tappedValues.Add(x.Value));

        result.ShouldBeFailure();
        tappedValues.Should().HaveCount(0);
    }
    
    [Fact]
    public void Should_TapAll_IEnumerable_Of_ValueResults_With_Func_Result()
    {
        var results = new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        };
        
        var result = results.TapAll(x => Result.Success());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
    }
}