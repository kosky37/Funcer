using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

using Result = Funcer.Result;

public class ResultEnsureTests_Task_Right
{ 
    public static TheoryData<Result, Func<Task<bool>>, Action<Result>> TestData1 => new()
    {
        { TestResult.Success, Tasks.Returns.True, Assertions.ResultSuccess },
        { TestResult.Success, Tasks.Returns.False, Assertions.ResultFailure },
        { TestResult.Failure, Tasks.Returns.True, Assertions.ResultFailure },
        { TestResult.Failure, Tasks.Returns.False, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task Result_Ensure_ConditionTask(Result first, Func<Task<bool>> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result);
    }
}