using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Map;

public class ResultMapTests
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Functions.Returns.Success.Empty, Assertions.ResultSuccess },
            new object[] { Results.Success.Nothing, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.Success.Empty, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Return_Result_When_Map_On_Result_With_Result(Result first, Func<Result> next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Nothing, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public void Should_Return_ValueResult_When_Map_On_Result_With_ValueResult(Result first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);
            
        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Functions.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Nothing, Functions.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData3))]
    public void Should_Return_Result_When_Map_On_Result_With_Action(Result first, Action next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData4 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Nothing, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData4))]
    public void Should_Return_ValueResult_When_Map_On_Result_With_Function(Result first, Func<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
}