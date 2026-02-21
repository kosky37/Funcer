using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

using Result = Funcer.Result;

public class ResultForkTests
{
    // Test data for bool condition with value mappers
    public static TheoryData<Result, bool, Func<Types.Alpha>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ValueMappers => new()
    {
        { TestResult.Success, true, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Failure, true, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, false, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ValueMappers))]
    public void Result_Fork_BoolCondition_ValueMappers(
        Result first,
        bool condition,
        Func<Types.Alpha> onTrue,
        Func<Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with Result mappers
    public static TheoryData<Result, bool, Func<Result<Types.Alpha>>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ResultMappers => new()
    {
        { TestResult.Success, true, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, true, TestFunc.Returns.Failure.Alpha, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Success, false, TestFunc.Returns.Success.Alpha1, TestFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, true, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, false, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ResultMappers))]
    public void Result_Fork_BoolCondition_ResultMappers(
        Result first,
        bool condition,
        Func<Result<Types.Alpha>> onTrue,
        Func<Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with mixed mappers (value onTrue, Result onFalse)
    public static TheoryData<Result, bool, Func<Types.Alpha>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_MixedMappers1 => new()
    {
        { TestResult.Success, true, TestFunc.Returns.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, TestFunc.Returns.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, false, TestFunc.Returns.Alpha1, TestFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, true, TestFunc.Returns.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_MixedMappers1))]
    public void Result_Fork_BoolCondition_MixedMappers_ValueTrue_ResultFalse(
        Result first,
        bool condition,
        Func<Types.Alpha> onTrue,
        Func<Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with mixed mappers (Result onTrue, value onFalse)
    public static TheoryData<Result, bool, Func<Result<Types.Alpha>>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_MixedMappers2 => new()
    {
        { TestResult.Success, true, TestFunc.Returns.Success.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, false, TestFunc.Returns.Success.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, true, TestFunc.Returns.Failure.Alpha, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, false, TestFunc.Returns.Success.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_MixedMappers2))]
    public void Result_Fork_BoolCondition_MixedMappers_ResultTrue_ValueFalse(
        Result first,
        bool condition,
        Func<Result<Types.Alpha>> onTrue,
        Func<Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with value mappers
    public static TheoryData<Result, Func<bool>, Func<Types.Alpha>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ValueMappers => new()
    {
        { TestResult.Success, TestFunc.Returns.True, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Failure, TestFunc.Returns.True, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.False, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ValueMappers))]
    public void Result_Fork_FuncBoolCondition_ValueMappers(
        Result first,
        Func<bool> condition,
        Func<Types.Alpha> onTrue,
        Func<Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with Result mappers
    public static TheoryData<Result, Func<bool>, Func<Result<Types.Alpha>>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ResultMappers => new()
    {
        { TestResult.Success, TestFunc.Returns.True, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.True, TestFunc.Returns.Failure.Alpha, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Success, TestFunc.Returns.False, TestFunc.Returns.Success.Alpha1, TestFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.True, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ResultMappers))]
    public void Result_Fork_FuncBoolCondition_ResultMappers(
        Result first,
        Func<bool> condition,
        Func<Result<Types.Alpha>> onTrue,
        Func<Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with mixed mappers
    public static TheoryData<Result, Func<bool>, Func<Types.Alpha>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_MixedMappers => new()
    {
        { TestResult.Success, TestFunc.Returns.True, TestFunc.Returns.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, TestFunc.Returns.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, TestFunc.Returns.Alpha1, TestFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.True, TestFunc.Returns.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_MixedMappers))]
    public void Result_Fork_FuncBoolCondition_MixedMappers(
        Result first,
        Func<bool> condition,
        Func<Types.Alpha> onTrue,
        Func<Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
