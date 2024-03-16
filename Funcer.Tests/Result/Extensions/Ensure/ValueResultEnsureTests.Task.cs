using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

public class ValueResultEnsureTests_Task
{
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Task<bool>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Returns.True, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Returns.False, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.True, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.False, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_Ensure_ConditionTask(Task<Result<Types.Alpha>> first, Func<Task<bool>> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Task<bool>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V2, AsyncFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Success.V2, AsyncFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_Ensure_ConditionTaskWithParameter(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task<bool>> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, expectedValue);
    }
}