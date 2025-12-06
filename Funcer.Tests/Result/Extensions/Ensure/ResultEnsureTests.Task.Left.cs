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
            .Ensure(condition, TestValues.Error);

        validate(result);
    }

    public static TheoryData<Task<Result>, Func<bool>, Action<Result>> TestData2 => new()
    {
        { TestResult.Async.Success, TestFunc.Returns.True, Assertions.ResultSuccess },
        { TestResult.Async.Success, TestFunc.Returns.False, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestFunc.Returns.True, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestFunc.Returns.False, Assertions.ResultFailure }
    };
    
    [Theory, MemberData(nameof(TestData2))]
    public async Task ResultTask_Ensure_ConditionFunction(Task<Result> first, Func<bool> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }

    public static TheoryData<Task<Result>, Result<bool>, Action<Result>> TestData3 => new()
    {
        { TestResult.Async.Success, TestResult.Bool.SuccessTrue, Assertions.ResultSuccess },
        { TestResult.Async.Success, TestResult.Bool.SuccessFalse, Assertions.ResultFailure },
        { TestResult.Async.Success, TestResult.Bool.Failure, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestResult.Bool.SuccessTrue, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestResult.Bool.SuccessFalse, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestResult.Bool.Failure, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ResultTask_Ensure_ResultBoolCondition(Task<Result> first, Result<bool> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }

    public static TheoryData<Task<Result>, Func<Result<bool>>, Action<Result>> TestData4 => new()
    {
        { TestResult.Async.Success, TestFunc.Returns.BoolSuccessTrue, Assertions.ResultSuccess },
        { TestResult.Async.Success, TestFunc.Returns.BoolSuccessFalse, Assertions.ResultFailure },
        { TestResult.Async.Success, TestFunc.Returns.BoolFailure, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestFunc.Returns.BoolSuccessTrue, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestFunc.Returns.BoolSuccessFalse, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestFunc.Returns.BoolFailure, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ResultTask_Ensure_ResultBoolConditionFunction(Task<Result> first, Func<Result<bool>> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }
}