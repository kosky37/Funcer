using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

public class ValueResultForkTests_Task_Right
{
    // Test data for bool condition with value mappers
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Task<Types.Alpha>>, Func<Types.Beta, Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ValueMappers => new()
    {
        { TestResult.Beta.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, false, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ValueMappers))]
    public async Task ValueResult_Fork_BoolCondition_ValueMappersTask(
        Result<Types.Beta> first,
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
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Task<Result<Types.Alpha>>>, Func<Types.Beta, Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ResultMappers => new()
    {
        { TestResult.Beta.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, true, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ResultMappers))]
    public async Task ValueResult_Fork_BoolCondition_ResultMappersTask(
        Result<Types.Beta> first,
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
    public static TheoryData<Result<Types.Beta>, bool, Func<Task<Types.Alpha>>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_NoParamValueMappers => new()
    {
        { TestResult.Beta.Success.V1, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, true, AsyncFunc.Returns.Alpha1, () => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_NoParamValueMappers))]
    public async Task ValueResult_Fork_BoolCondition_NoParamValueMappersTask(
        Result<Types.Beta> first,
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
    public static TheoryData<Result<Types.Beta>, bool, Func<Task<Result<Types.Alpha>>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_NoParamResultMappers => new()
    {
        { TestResult.Beta.Success.V1, true, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, true, AsyncFunc.Returns.Failure.Alpha, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, false, AsyncFunc.Returns.Success.Alpha1, () => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_NoParamResultMappers))]
    public async Task ValueResult_Fork_BoolCondition_NoParamResultMappersTask(
        Result<Types.Beta> first,
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
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Task<Types.Alpha>>, Func<Types.Beta, Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_MixedMappers1 => new()
    {
        { TestResult.Beta.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Alpha1, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, true, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_MixedMappers1))]
    public async Task ValueResult_Fork_BoolCondition_MixedMappersTask_ValueTrue_ResultFalse(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Task<Types.Alpha>> onTrue,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with mixed mappers (Result onTrue, value onFalse)
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Task<Result<Types.Alpha>>>, Func<Types.Beta, Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_MixedMappers2 => new()
    {
        { TestResult.Beta.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, true, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, false, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_MixedMappers2))]
    public async Task ValueResult_Fork_BoolCondition_MixedMappersTask_ResultTrue_ValueFalse(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onTrue,
        Func<Types.Beta, Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with value mappers
    public static TheoryData<Result<Types.Beta>, Func<bool>, Func<Types.Beta, Task<Types.Alpha>>, Func<Types.Beta, Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ValueMappers => new()
    {
        { TestResult.Beta.Success.V1, TestFunc.Returns.True, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, TestFunc.Returns.False, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, TestFunc.Returns.True, AsyncFunc.Takes.Beta.Returns.Alpha1, _ => Task.FromResult(TestValues.Alpha2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ValueMappers))]
    public async Task ValueResult_Fork_FuncBoolCondition_ValueMappersTask(
        Result<Types.Beta> first,
        Func<bool> condition,
        Func<Types.Beta, Task<Types.Alpha>> onTrue,
        Func<Types.Beta, Task<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with Result mappers
    public static TheoryData<Result<Types.Beta>, Func<bool>, Func<Types.Beta, Task<Result<Types.Alpha>>>, Func<Types.Beta, Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ResultMappers => new()
    {
        { TestResult.Beta.Success.V1, TestFunc.Returns.True, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, TestFunc.Returns.False, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, TestFunc.Returns.True, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, TestFunc.Returns.True, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, _ => Task.FromResult(TestResult.Alpha.Success.V2), TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ResultMappers))]
    public async Task ValueResult_Fork_FuncBoolCondition_ResultMappersTask(
        Result<Types.Beta> first,
        Func<bool> condition,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onTrue,
        Func<Types.Beta, Task<Result<Types.Alpha>>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<TValue, bool> condition with value mappers
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, bool>, Func<Types.Alpha, Task<Types.Beta>>, Func<Types.Alpha, Task<Types.Beta>>, Types.Beta, Action<Result<Types.Beta>, Types.Beta>> TestData_FuncValueBoolCondition_ValueMappers => new()
    {
        { TestResult.Alpha.Success.V1, _ => true, AsyncFunc.Takes.Alpha.Returns.Beta1, _ => Task.FromResult(TestValues.Beta2), TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, _ => false, AsyncFunc.Takes.Alpha.Returns.Beta1, _ => Task.FromResult(TestValues.Beta2), TestValues.Beta2, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Failure, _ => true, AsyncFunc.Takes.Alpha.Returns.Beta1, _ => Task.FromResult(TestValues.Beta2), TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
    };

    [Theory, MemberData(nameof(TestData_FuncValueBoolCondition_ValueMappers))]
    public async Task ValueResult_Fork_FuncValueBoolCondition_ValueMappersTask(
        Result<Types.Alpha> first,
        Func<Types.Alpha, bool> condition,
        Func<Types.Alpha, Task<Types.Beta>> onTrue,
        Func<Types.Alpha, Task<Types.Beta>> onFalse,
        Types.Beta expectedValue,
        Action<Result<Types.Beta>, Types.Beta> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<TValue, bool> condition with Result mappers
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, bool>, Func<Types.Alpha, Task<Result<Types.Beta>>>, Func<Types.Alpha, Task<Result<Types.Beta>>>, Types.Beta, Action<Result<Types.Beta>, Types.Beta>> TestData_FuncValueBoolCondition_ResultMappers => new()
    {
        { TestResult.Alpha.Success.V1, _ => true, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, _ => Task.FromResult(TestResult.Beta.Success.V2), TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, _ => false, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, _ => Task.FromResult(TestResult.Beta.Success.V2), TestValues.Beta2, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, _ => true, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, _ => Task.FromResult(TestResult.Beta.Success.V2), TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
        { TestResult.Alpha.Failure, _ => true, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, _ => Task.FromResult(TestResult.Beta.Success.V2), TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
    };

    [Theory, MemberData(nameof(TestData_FuncValueBoolCondition_ResultMappers))]
    public async Task ValueResult_Fork_FuncValueBoolCondition_ResultMappersTask(
        Result<Types.Alpha> first,
        Func<Types.Alpha, bool> condition,
        Func<Types.Alpha, Task<Result<Types.Beta>>> onTrue,
        Func<Types.Alpha, Task<Result<Types.Beta>>> onFalse,
        Types.Beta expectedValue,
        Action<Result<Types.Beta>, Types.Beta> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
