using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

using Result = Funcer.Result;

public class ResultEnsureTests_Task_Left
{
    public static TheoryData<Task<Result>, bool, Action<Result>> TestData1 => new()
    {
        { TestResult.Async.Success, true, Assertions.ResultSuccess },
        { TestResult.Async.Success, false, Assertions.ResultFailure },
        { TestResult.Async.Failure, true, Assertions.ResultFailure },
        { TestResult.Async.Failure, false, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_Ensure_Condition(Task<Result> first, bool condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result);
    }

    public static TheoryData<Task<Result>, Func<bool>, Action<Result>> TestData2 => new()
    {
        { TestResult.Async.Success, Functions.Returns.True, Assertions.ResultSuccess },
        { TestResult.Async.Success, Functions.Returns.False, Assertions.ResultFailure },
        { TestResult.Async.Failure, Functions.Returns.True, Assertions.ResultFailure },
        { TestResult.Async.Failure, Functions.Returns.False, Assertions.ResultFailure }
    };
    
    [Theory, MemberData(nameof(TestData2))]
    public async Task ResultTask_Ensure_ConditionFunction(Task<Result> first, Func<bool> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result);
    }
}