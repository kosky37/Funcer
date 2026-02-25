using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

using Result = Funcer.Result;

public class ResultForkTests_Task_First
{
    // Test data for bool condition with mixed mappers (onTrue async, onFalse sync)
    public static TheoryData<Result, bool, Func<Task<Types.Alpha>>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_AsyncTrueSyncFalse => new()
    {
        { TestResult.Success, true, AsyncFunc.Returns.Alpha1, TestFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, AsyncFunc.Returns.Alpha1, TestFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Failure, true, AsyncFunc.Returns.Alpha1, TestFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_AsyncTrueSyncFalse))]
    public async Task Result_Fork_BoolCondition_MixedMappers_AsyncTrue_SyncFalse_Value(
        Result first,
        bool condition,
        Func<Task<Types.Alpha>> onTrue,
        Func<Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with mixed mappers (onTrue sync, onFalse async)
    public static TheoryData<Result, bool, Func<Types.Alpha>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_SyncTrueAsyncFalse => new()
    {
        { TestResult.Success, true, TestFunc.Returns.Alpha1, AsyncFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, TestFunc.Returns.Alpha1, AsyncFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Failure, false, TestFunc.Returns.Alpha1, AsyncFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_SyncTrueAsyncFalse))]
    public async Task Result_Fork_BoolCondition_MixedMappers_SyncTrue_AsyncFalse_Value(
        Result first,
        bool condition,
        Func<Types.Alpha> onTrue,
        Func<Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data with Result mappers - mixed async/sync
    public static TheoryData<Result, bool, Func<Task<Result<Types.Alpha>>>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_AsyncResultTrueSyncResultFalse => new()
    {
        { TestResult.Success, true, AsyncFunc.Returns.Success.Alpha1, TestFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, AsyncFunc.Returns.Success.Alpha1, TestFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, true, AsyncFunc.Returns.Failure.Alpha, TestFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, true, AsyncFunc.Returns.Success.Alpha1, TestFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_AsyncResultTrueSyncResultFalse))]
    public async Task Result_Fork_BoolCondition_MixedMappers_AsyncResultTrue_SyncResultFalse(
        Result first,
        bool condition,
        Func<Task<Result<Types.Alpha>>> onTrue,
        Func<Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data with Result mappers - mixed sync/async
    public static TheoryData<Result, bool, Func<Result<Types.Alpha>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_SyncResultTrueAsyncResultFalse => new()
    {
        { TestResult.Success, true, TestFunc.Returns.Success.Alpha1, AsyncFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, TestFunc.Returns.Success.Alpha1, AsyncFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, TestFunc.Returns.Success.Alpha1, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, false, TestFunc.Returns.Success.Alpha1, AsyncFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_SyncResultTrueAsyncResultFalse))]
    public async Task Result_Fork_BoolCondition_MixedMappers_SyncResultTrue_AsyncResultFalse(
        Result first,
        bool condition,
        Func<Result<Types.Alpha>> onTrue,
        Func<Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with mixed mappers
    public static TheoryData<Result, Func<bool>, Func<Task<Types.Alpha>>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_MixedMappers => new()
    {
        { TestResult.Success, TestFunc.Returns.True, AsyncFunc.Returns.Alpha1, TestFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, AsyncFunc.Returns.Alpha1, TestFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Failure, TestFunc.Returns.True, AsyncFunc.Returns.Alpha1, TestFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_MixedMappers))]
    public async Task Result_Fork_FuncBoolCondition_MixedMappers(
        Result first,
        Func<bool> condition,
        Func<Task<Types.Alpha>> onTrue,
        Func<Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
