using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

public class ValueResultForkTests_Task
{
    // Test data for bool condition with value mappers
    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Types.Beta, Task<Types.Alpha>>, Func<Types.Beta, Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ValueMappers => new()
    {
        { TestResult.Beta.Async.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, false, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ValueMappers))]
    public async Task ValueResultTask_Fork_BoolCondition_ValueMappers(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Types.Beta, Task<Types.Alpha>> onTrue,
        Func<Types.Beta, Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with Result mappers
    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Types.Beta, Task<Result<Types.Alpha>>>, Func<Types.Beta, Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ResultMappers => new()
    {
        { TestResult.Beta.Async.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, true, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ResultMappers))]
    public async Task ValueResultTask_Fork_BoolCondition_ResultMappers(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onTrue,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with no-param value mappers
    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Task<Types.Alpha>>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_NoParamValueMappers => new()
    {
        { TestResult.Beta.Async.Success.V1, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_NoParamValueMappers))]
    public async Task ValueResultTask_Fork_BoolCondition_NoParamValueMappers(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Task<Types.Alpha>> onTrue,
        Func<Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with no-param Result mappers
    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Task<Result<Types.Alpha>>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_NoParamResultMappers => new()
    {
        { TestResult.Beta.Async.Success.V1, true, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, true, AsyncFunc.Returns.Failure.Alpha, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, false, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_NoParamResultMappers))]
    public async Task ValueResultTask_Fork_BoolCondition_NoParamResultMappers(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Task<Result<Types.Alpha>>> onTrue,
        Func<Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with value mappers
    public static TheoryData<Task<Result<Types.Beta>>, Func<bool>, Func<Types.Beta, Task<Types.Alpha>>, Func<Types.Beta, Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ValueMappers => new()
    {
        { TestResult.Beta.Async.Success.V1, TestFunc.Returns.True, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, TestFunc.Returns.False, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, TestFunc.Returns.True, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ValueMappers))]
    public async Task ValueResultTask_Fork_FuncBoolCondition_ValueMappers(
        Task<Result<Types.Beta>> first,
        Func<bool> condition,
        Func<Types.Beta, Task<Types.Alpha>> onTrue,
        Func<Types.Beta, Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<TValue, bool> condition with value mappers
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, bool>, Func<Types.Alpha, Task<Types.Beta>>, Func<Types.Alpha, Task<Types.Beta>>, Types.Beta, Action<Result<Types.Beta>, Types.Beta>> TestData_FuncValueBoolCondition_ValueMappers => new()
    {
        { TestResult.Alpha.Async.Success.V1, _ => true, AsyncFunc.Takes.Alpha.Returns.Beta1, _ => Task.FromResult(TestValues.Beta2), TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Async.Success.V1, _ => false, AsyncFunc.Takes.Alpha.Returns.Beta1, _ => Task.FromResult(TestValues.Beta2), TestValues.Beta2, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Async.Failure, _ => true, AsyncFunc.Takes.Alpha.Returns.Beta1, _ => Task.FromResult(TestValues.Beta2), TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
    };

    [Theory, MemberData(nameof(TestData_FuncValueBoolCondition_ValueMappers))]
    public async Task ValueResultTask_Fork_FuncValueBoolCondition_ValueMappers(
        Task<Result<Types.Alpha>> first,
        Func<Types.Alpha, bool> condition,
        Func<Types.Alpha, Task<Types.Beta>> onTrue,
        Func<Types.Alpha, Task<Types.Beta>> onFalse,
        Types.Beta expectedValue,
        Action<Result<Types.Beta>, Types.Beta> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
