using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

using Result = Funcer.Result;

public class ResultForkTests_Task_Right
{
    // Test data for bool condition with value mappers
    public static TheoryData<Result, bool, Func<Task<Types.Alpha>>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ValueMappers => new()
    {
        { TestResult.Success, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Failure, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, false, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ValueMappers))]
    public async Task Result_Fork_BoolCondition_ValueMappersTask(
        Result first,
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
    public static TheoryData<Result, bool, Func<Task<Result<Types.Alpha>>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ResultMappers => new()
    {
        { TestResult.Success, true, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, true, AsyncFunc.Returns.Failure.Alpha, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Success, false, AsyncFunc.Returns.Success.Alpha1, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, true, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, false, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ResultMappers))]
    public async Task Result_Fork_BoolCondition_ResultMappersTask(
        Result first,
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
    public static TheoryData<Result, bool, Func<Task<Types.Alpha>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_MixedMappers1 => new()
    {
        { TestResult.Success, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, false, AsyncFunc.Returns.Alpha1, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_MixedMappers1))]
    public async Task Result_Fork_BoolCondition_MixedMappersTask_ValueTrue_ResultFalse(
        Result first,
        bool condition,
        Func<Task<Types.Alpha>> onTrue,
        Func<Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with mixed mappers (Result onTrue, value onFalse)
    public static TheoryData<Result, bool, Func<Task<Result<Types.Alpha>>>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_MixedMappers2 => new()
    {
        { TestResult.Success, true, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, true, AsyncFunc.Returns.Failure.Alpha, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, false, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_MixedMappers2))]
    public async Task Result_Fork_BoolCondition_MixedMappersTask_ResultTrue_ValueFalse(
        Result first,
        bool condition,
        Func<Task<Result<Types.Alpha>>> onTrue,
        Func<Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with value mappers
    public static TheoryData<Result, Func<bool>, Func<Task<Types.Alpha>>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ValueMappers => new()
    {
        { TestResult.Success, TestFunc.Returns.True, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Failure, TestFunc.Returns.True, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.False, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ValueMappers))]
    public async Task Result_Fork_FuncBoolCondition_ValueMappersTask(
        Result first,
        Func<bool> condition,
        Func<Task<Types.Alpha>> onTrue,
        Func<Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with Result mappers
    public static TheoryData<Result, Func<bool>, Func<Task<Result<Types.Alpha>>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ResultMappers => new()
    {
        { TestResult.Success, TestFunc.Returns.True, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.True, AsyncFunc.Returns.Failure.Alpha, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Success, TestFunc.Returns.False, AsyncFunc.Returns.Success.Alpha1, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.True, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ResultMappers))]
    public async Task Result_Fork_FuncBoolCondition_ResultMappersTask(
        Result first,
        Func<bool> condition,
        Func<Task<Result<Types.Alpha>>> onTrue,
        Func<Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with mixed mappers
    public static TheoryData<Result, Func<bool>, Func<Task<Types.Alpha>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_MixedMappers => new()
    {
        { TestResult.Success, TestFunc.Returns.True, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, AsyncFunc.Returns.Alpha1, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.True, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_MixedMappers))]
    public async Task Result_Fork_FuncBoolCondition_MixedMappersTask(
        Result first,
        Func<bool> condition,
        Func<Task<Types.Alpha>> onTrue,
        Func<Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
