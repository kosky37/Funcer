using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Ensure;

public class ResultEnsureTests_Task_Left
{ 
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, true, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Nothing, false, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, true, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, false, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_Ensure_Condition(Task<Result> first, bool condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Functions.Returns.True, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Nothing, Functions.Returns.False, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Functions.Returns.True, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Functions.Returns.False, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ResultTask_Ensure_ConditionFunction(Task<Result> first, Func<bool> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result);
    }
}