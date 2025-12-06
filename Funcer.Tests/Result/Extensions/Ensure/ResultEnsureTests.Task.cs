using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

using Result = Funcer.Result;

public class ResultEnsureTests_Task
{
    public static TheoryData<Task<Result>, Func<Task<bool>>, Action<Result>> TestData1 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.True, Assertions.ResultSuccess },
        { TestResult.Async.Success, AsyncFunc.Returns.False, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.True, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.False, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_Ensure_ConditionTask(Task<Result> first, Func<Task<bool>> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }

    public static TheoryData<Task<Result>, Func<Task<Result<bool>>>, Action<Result>> TestData2 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.BoolSuccessTrue, Assertions.ResultSuccess },
        { TestResult.Async.Success, AsyncFunc.Returns.BoolSuccessFalse, Assertions.ResultFailure },
        { TestResult.Async.Success, AsyncFunc.Returns.BoolFailure, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.BoolSuccessTrue, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.BoolSuccessFalse, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.BoolFailure, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ResultTask_Ensure_ResultBoolConditionTask(Task<Result> first, Func<Task<Result<bool>>> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }
}