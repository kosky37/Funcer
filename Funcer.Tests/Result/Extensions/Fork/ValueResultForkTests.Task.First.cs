using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

public class ValueResultForkTests_Task_First
{
    // Test data for bool condition with mixed mappers (onTrue async, onFalse sync)
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Task<Types.Alpha>>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_AsyncTrueSyncFalse => new()
    {
        { TestResult.Beta.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_AsyncTrueSyncFalse))]
    public async Task ValueResult_Fork_BoolCondition_MixedMappers_AsyncTrue_SyncFalse_Value(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Task<Types.Alpha>> onTrue,
        Func<Types.Beta, Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with mixed mappers (onTrue sync, onFalse async)
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Types.Alpha>, Func<Types.Beta, Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_SyncTrueAsyncFalse => new()
    {
        { TestResult.Beta.Success.V1, true, TestFunc.Takes.Beta.Returns.Alpha1, AsyncFunc.Takes.Beta.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Takes.Beta.Returns.Alpha1, AsyncFunc.Takes.Beta.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, false, TestFunc.Takes.Beta.Returns.Alpha1, AsyncFunc.Takes.Beta.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_SyncTrueAsyncFalse))]
    public async Task ValueResult_Fork_BoolCondition_MixedMappers_SyncTrue_AsyncFalse_Value(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Types.Alpha> onTrue,
        Func<Types.Beta, Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data with Result mappers - mixed async/sync
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Task<Result<Types.Alpha>>>, Func<Types.Beta, Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_AsyncResultTrueSyncResultFalse => new()
    {
        { TestResult.Beta.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestFunc.Takes.Beta.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestFunc.Takes.Beta.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, TestFunc.Takes.Beta.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, true, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestFunc.Takes.Beta.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_AsyncResultTrueSyncResultFalse))]
    public async Task ValueResult_Fork_BoolCondition_MixedMappers_AsyncResultTrue_SyncResultFalse(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onTrue,
        Func<Types.Beta, Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data with Result mappers - mixed sync/async
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Result<Types.Alpha>>, Func<Types.Beta, Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_SyncResultTrueAsyncResultFalse => new()
    {
        { TestResult.Beta.Success.V1, true, TestFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_SyncResultTrueAsyncResultFalse))]
    public async Task ValueResult_Fork_BoolCondition_MixedMappers_SyncResultTrue_AsyncResultFalse(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Result<Types.Alpha>> onTrue,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with mixed mappers
    public static TheoryData<Result<Types.Beta>, Func<bool>, Func<Types.Beta, Task<Types.Alpha>>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_MixedMappers => new()
    {
        { TestResult.Beta.Success.V1, TestFunc.Returns.True, AsyncFunc.Takes.Beta.Returns.Alpha1, TestFunc.Takes.Beta.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, TestFunc.Returns.False, AsyncFunc.Takes.Beta.Returns.Alpha1, TestFunc.Takes.Beta.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, TestFunc.Returns.True, AsyncFunc.Takes.Beta.Returns.Alpha1, TestFunc.Takes.Beta.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_MixedMappers))]
    public async Task ValueResult_Fork_FuncBoolCondition_MixedMappers(
        Result<Types.Beta> first,
        Func<bool> condition,
        Func<Types.Beta, Task<Types.Alpha>> onTrue,
        Func<Types.Beta, Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<TValue, bool> condition with mixed mappers
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, bool>, Func<Types.Alpha, Task<Types.Beta>>, Func<Types.Alpha, Types.Beta>, Types.Beta, Action<Result<Types.Beta>, Types.Beta>> TestData_FuncValueBoolCondition_MixedMappers => new()
    {
        { TestResult.Alpha.Success.V1, _ => true, AsyncFunc.Takes.Alpha.Returns.Beta1, TestFunc.Takes.Alpha.Returns.Beta1, TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, _ => false, AsyncFunc.Takes.Alpha.Returns.Beta1, TestFunc.Takes.Alpha.Returns.Beta1, TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Failure, _ => true, AsyncFunc.Takes.Alpha.Returns.Beta1, TestFunc.Takes.Alpha.Returns.Beta1, TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
    };

    [Theory, MemberData(nameof(TestData_FuncValueBoolCondition_MixedMappers))]
    public async Task ValueResult_Fork_FuncValueBoolCondition_MixedMappers(
        Result<Types.Alpha> first,
        Func<Types.Alpha, bool> condition,
        Func<Types.Alpha, Task<Types.Beta>> onTrue,
        Func<Types.Alpha, Types.Beta> onFalse,
        Types.Beta expectedValue,
        Action<Result<Types.Beta>, Types.Beta> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
    
    
    
    
    // Test data for Task<Result> with Func<TValue, bool> condition and mixed mappers (onTrue sync value, onFalse async result)
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, bool>, Func<Types.Alpha, Types.Beta>, Func<Types.Alpha, Task<Result<Types.Beta>>>, Types.Beta, Action<Result<Types.Beta>, Types.Beta>> TestData_TaskResult_FuncValueBoolCondition_SyncValueTrue_AsyncResultFalse => new()
    {
        { TestResult.Alpha.Async.Success.V1, _ => true, TestFunc.Takes.Alpha.Returns.Beta1, AsyncFunc.Takes.Alpha.Returns.Success.Beta2, TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Async.Success.V1, _ => false, TestFunc.Takes.Alpha.Returns.Beta1, AsyncFunc.Takes.Alpha.Returns.Success.Beta2, TestValues.Beta2, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Async.Success.V1, _ => true, TestFunc.Takes.Alpha.Returns.Beta1, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Async.Success.V1, _ => false, TestFunc.Takes.Alpha.Returns.Beta1, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, TestValues.Beta2, (result, _) => result.ShouldBeFailure() },
        { TestResult.Alpha.Async.Failure, _ => true, TestFunc.Takes.Alpha.Returns.Beta1, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
    };

    [Theory, MemberData(nameof(TestData_TaskResult_FuncValueBoolCondition_SyncValueTrue_AsyncResultFalse))]
    public async Task TaskValueResult_Fork_FuncValueBoolCondition_SyncValueTrue_AsyncResultFalse(
        Task<Result<Types.Alpha>> first,
        Func<Types.Alpha, bool> condition,
        Func<Types.Alpha, Types.Beta> onTrue,
        Func<Types.Alpha, Task<Result<Types.Beta>>> onFalse,
        Types.Beta expectedValue,
        Action<Result<Types.Beta>, Types.Beta> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Task<Result> with bool condition - mixed value mappers
    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Types.Beta, Task<Types.Alpha>>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_TaskResult_BoolCondition_AsyncValueTrue_SyncValueFalse => new()
    {
        { TestResult.Beta.Async.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_TaskResult_BoolCondition_AsyncValueTrue_SyncValueFalse))]
    public async Task TaskValueResult_Fork_BoolCondition_AsyncValueTrue_SyncValueFalse(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Types.Beta, Task<Types.Alpha>> onTrue,
        Func<Types.Beta, Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Types.Beta, Types.Alpha>, Func<Types.Beta, Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_TaskResult_BoolCondition_SyncValueTrue_AsyncValueFalse => new()
    {
        { TestResult.Beta.Async.Success.V1, true, TestFunc.Takes.Beta.Returns.Alpha1, AsyncFunc.Takes.Beta.Returns.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, TestFunc.Takes.Beta.Returns.Alpha1, AsyncFunc.Takes.Beta.Returns.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, false, TestFunc.Takes.Beta.Returns.Alpha1, AsyncFunc.Takes.Beta.Returns.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_TaskResult_BoolCondition_SyncValueTrue_AsyncValueFalse))]
    public async Task TaskValueResult_Fork_BoolCondition_SyncValueTrue_AsyncValueFalse(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Types.Beta, Types.Alpha> onTrue,
        Func<Types.Beta, Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Task<Result> with bool condition - mixed result mappers
    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Types.Beta, Task<Result<Types.Alpha>>>, Func<Types.Beta, Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_TaskResult_BoolCondition_AsyncResultTrue_SyncResultFalse => new()
    {
        { TestResult.Beta.Async.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestFunc.Takes.Beta.Returns.Success.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestFunc.Takes.Beta.Returns.Success.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, TestFunc.Takes.Beta.Returns.Success.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, true, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestFunc.Takes.Beta.Returns.Success.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_TaskResult_BoolCondition_AsyncResultTrue_SyncResultFalse))]
    public async Task TaskValueResult_Fork_BoolCondition_AsyncResultTrue_SyncResultFalse(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onTrue,
        Func<Types.Beta, Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Types.Beta, Result<Types.Alpha>>, Func<Types.Beta, Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_TaskResult_BoolCondition_SyncResultTrue_AsyncResultFalse => new()
    {
        { TestResult.Beta.Async.Success.V1, true, TestFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Success.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Success.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Success.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_TaskResult_BoolCondition_SyncResultTrue_AsyncResultFalse))]
    public async Task TaskValueResult_Fork_BoolCondition_SyncResultTrue_AsyncResultFalse(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Types.Beta, Result<Types.Alpha>> onTrue,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
