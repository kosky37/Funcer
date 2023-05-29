using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Ensure;

public class ResultEnsureTests
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, true, Assertions.ResultSuccess },
            new object[] { Results.Success.Nothing, false, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, true, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, false, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Return_Correct_Result_With_Condition(Result first, bool condition, Action<Result> validate)
    {
        var result = first
            .Ensure(condition, Values.TestError);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Functions.Returns.True, Assertions.ResultSuccess },
            new object[] { Results.Success.Nothing, Functions.Returns.False, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.True, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.False, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public void Should_Return_Correct_Result_With_Condition_Function(Result first, Func<bool> condition, Action<Result> validate)
    {
        var result = first
            .Ensure(condition, Values.TestError);

        validate(result);
    }
}