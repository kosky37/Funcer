using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

using Result = Funcer.Result;

public class ResultEnsureTests_Task
{
    public static TheoryData<Task<Result>, Func<Task<bool>>, Action<Result>> TestData1 => new()
    {
        { TestResult.Async.Success, Tasks.Returns.True, Assertions.ResultSuccess },
        { TestResult.Async.Success, Tasks.Returns.False, Assertions.ResultFailure },
        { TestResult.Async.Failure, Tasks.Returns.True, Assertions.ResultFailure },
        { TestResult.Async.Failure, Tasks.Returns.False, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_Ensure_ConditionTask(Task<Result> first, Func<Task<bool>> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result);
    }
}