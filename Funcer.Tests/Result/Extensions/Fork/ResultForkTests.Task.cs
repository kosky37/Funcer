using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

using Result = Funcer.Result;

public class ResultForkTests_Task
{
    // Test data for bool condition with value mappers
    public static TheoryData<Task<Result>, bool, Func<Task<Types.Alpha>>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ValueMappers => new()
    {
        { TestResult.Async.Success, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, false, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Async.Failure, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Async.Failure, false, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ValueMappers))]
    public async Task ResultTask_Fork_BoolCondition_ValueMappers(
        Task<Result> first,
        bool condition,
        Func<Task<Types.Alpha>> onTrue,
        Func<Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with Result mappers
    public static TheoryData<Task<Result>, bool, Func<Task<Result<Types.Alpha>>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ResultMappers => new()
    {
        { TestResult.Async.Success, true, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, false, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, true, AsyncFunc.Returns.Failure.Alpha, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Async.Success, false, AsyncFunc.Returns.Success.Alpha1, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Async.Failure, true, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ResultMappers))]
    public async Task ResultTask_Fork_BoolCondition_ResultMappers(
        Task<Result> first,
        bool condition,
        Func<Task<Result<Types.Alpha>>> onTrue,
        Func<Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with mixed mappers (value onTrue, Result onFalse)
    public static TheoryData<Task<Result>, bool, Func<Task<Types.Alpha>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_MixedMappers1 => new()
    {
        { TestResult.Async.Success, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, false, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, false, AsyncFunc.Returns.Alpha1, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Async.Failure, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_MixedMappers1))]
    public async Task ResultTask_Fork_BoolCondition_MixedMappers_ValueTrue_ResultFalse(
        Task<Result> first,
        bool condition,
        Func<Task<Types.Alpha>> onTrue,
        Func<Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with value mappers
    public static TheoryData<Task<Result>, Func<bool>, Func<Task<Types.Alpha>>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ValueMappers => new()
    {
        { TestResult.Async.Success, TestFunc.Returns.True, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, TestFunc.Returns.False, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Async.Failure, TestFunc.Returns.True, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ValueMappers))]
    public async Task ResultTask_Fork_FuncBoolCondition_ValueMappers(
        Task<Result> first,
        Func<bool> condition,
        Func<Task<Types.Alpha>> onTrue,
        Func<Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
