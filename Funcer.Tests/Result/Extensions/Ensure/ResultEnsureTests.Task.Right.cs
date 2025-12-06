using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

using Result = Funcer.Result;

public class ResultEnsureTests_Task_Right
{ 
    public static TheoryData<Result, Func<Task<bool>>, Action<Result>> TestData1 => new()
    {
        { TestResult.Success, AsyncFunc.Returns.True, Assertions.ResultSuccess },
        { TestResult.Success, AsyncFunc.Returns.False, Assertions.ResultFailure },
        { TestResult.Failure, AsyncFunc.Returns.True, Assertions.ResultFailure },
        { TestResult.Failure, AsyncFunc.Returns.False, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task Result_Ensure_ConditionTask(Result first, Func<Task<bool>> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }

    public static TheoryData<Result, Func<Task<Result<bool>>>, Action<Result>> TestData2 => new()
    {
        { TestResult.Success, AsyncFunc.Returns.BoolSuccessTrue, Assertions.ResultSuccess },
        { TestResult.Success, AsyncFunc.Returns.BoolSuccessFalse, Assertions.ResultFailure },
        { TestResult.Success, AsyncFunc.Returns.BoolFailure, Assertions.ResultFailure },
        { TestResult.Failure, AsyncFunc.Returns.BoolSuccessTrue, Assertions.ResultFailure },
        { TestResult.Failure, AsyncFunc.Returns.BoolSuccessFalse, Assertions.ResultFailure },
        { TestResult.Failure, AsyncFunc.Returns.BoolFailure, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task Result_Ensure_ResultBoolConditionTask(Result first, Func<Task<Result<bool>>> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }
}