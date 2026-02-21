using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

public class ValueResultForkTests
{
    // Test data for bool condition with value mappers
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Types.Alpha>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ValueMappers => new()
    {
        { TestResult.Beta.Success.V1, true, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, true, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, false, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ValueMappers))]
    public void ValueResult_Fork_BoolCondition_ValueMappers(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Types.Alpha> onTrue,
        Func<Types.Beta, Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with Result mappers
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Result<Types.Alpha>>, Func<Types.Beta, Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ResultMappers => new()
    {
        { TestResult.Beta.Success.V1, true, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, true, TestFunc.Takes.Beta.Returns.Failure.Alpha, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Success.V1, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, TestFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, true, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ResultMappers))]
    public void ValueResult_Fork_BoolCondition_ResultMappers(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Result<Types.Alpha>> onTrue,
        Func<Types.Beta, Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with no-param mappers
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Alpha>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_NoParamValueMappers => new()
    {
        { TestResult.Beta.Success.V1, true, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, true, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, false, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_NoParamValueMappers))]
    public void ValueResult_Fork_BoolCondition_NoParamValueMappers(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Alpha> onTrue,
        Func<Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with no-param Result mappers
    public static TheoryData<Result<Types.Beta>, bool, Func<Result<Types.Alpha>>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_NoParamResultMappers => new()
    {
        { TestResult.Beta.Success.V1, true, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, true, TestFunc.Returns.Failure.Alpha, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Success.V1, false, TestFunc.Returns.Success.Alpha1, TestFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, true, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, false, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_NoParamResultMappers))]
    public void ValueResult_Fork_BoolCondition_NoParamResultMappers(
        Result<Types.Beta> first,
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
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Types.Alpha>, Func<Types.Beta, Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_MixedMappers1 => new()
    {
        { TestResult.Beta.Success.V1, true, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Takes.Beta.Returns.Alpha1, TestFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, true, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_MixedMappers1))]
    public void ValueResult_Fork_BoolCondition_MixedMappers_ValueTrue_ResultFalse(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Types.Alpha> onTrue,
        Func<Types.Beta, Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with mixed mappers (Result onTrue, value onFalse)
    public static TheoryData<Result<Types.Beta>, bool, Func<Types.Beta, Result<Types.Alpha>>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_MixedMappers2 => new()
    {
        { TestResult.Beta.Success.V1, true, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, true, TestFunc.Takes.Beta.Returns.Failure.Alpha, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_MixedMappers2))]
    public void ValueResult_Fork_BoolCondition_MixedMappers_ResultTrue_ValueFalse(
        Result<Types.Beta> first,
        bool condition,
        Func<Types.Beta, Result<Types.Alpha>> onTrue,
        Func<Types.Beta, Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with value mappers
    public static TheoryData<Result<Types.Beta>, Func<bool>, Func<Types.Beta, Types.Alpha>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ValueMappers => new()
    {
        { TestResult.Beta.Success.V1, TestFunc.Returns.True, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, TestFunc.Returns.False, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, TestFunc.Returns.True, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, TestFunc.Returns.False, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ValueMappers))]
    public void ValueResult_Fork_FuncBoolCondition_ValueMappers(
        Result<Types.Beta> first,
        Func<bool> condition,
        Func<Types.Beta, Types.Alpha> onTrue,
        Func<Types.Beta, Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with Result mappers
    public static TheoryData<Result<Types.Beta>, Func<bool>, Func<Types.Beta, Result<Types.Alpha>>, Func<Types.Beta, Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ResultMappers => new()
    {
        { TestResult.Beta.Success.V1, TestFunc.Returns.True, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, TestFunc.Returns.False, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, TestFunc.Returns.True, TestFunc.Takes.Beta.Returns.Failure.Alpha, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Success.V1, TestFunc.Returns.False, TestFunc.Takes.Beta.Returns.Success.Alpha1, TestFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, TestFunc.Returns.True, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ResultMappers))]
    public void ValueResult_Fork_FuncBoolCondition_ResultMappers(
        Result<Types.Beta> first,
        Func<bool> condition,
        Func<Types.Beta, Result<Types.Alpha>> onTrue,
        Func<Types.Beta, Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<TValue, bool> condition with value mappers
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, bool>, Func<Types.Alpha, Types.Beta>, Func<Types.Alpha, Types.Beta>, Types.Beta, Action<Result<Types.Beta>, Types.Beta>> TestData_FuncValueBoolCondition_ValueMappers => new()
    {
        { TestResult.Alpha.Success.V1, _ => true, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestValues.Beta2, TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, _ => false, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestValues.Beta2, TestValues.Beta2, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.IsFalse, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestValues.Beta2, TestValues.Beta2, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Failure, _ => true, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestValues.Beta2, TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
    };

    [Theory, MemberData(nameof(TestData_FuncValueBoolCondition_ValueMappers))]
    public void ValueResult_Fork_FuncValueBoolCondition_ValueMappers(
        Result<Types.Alpha> first,
        Func<Types.Alpha, bool> condition,
        Func<Types.Alpha, Types.Beta> onTrue,
        Func<Types.Alpha, Types.Beta> onFalse,
        Types.Beta expectedValue,
        Action<Result<Types.Beta>, Types.Beta> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<TValue, bool> condition with Result mappers
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, bool>, Func<Types.Alpha, Result<Types.Beta>>, Func<Types.Alpha, Result<Types.Beta>>, Types.Beta, Action<Result<Types.Beta>, Types.Beta>> TestData_FuncValueBoolCondition_ResultMappers => new()
    {
        { TestResult.Alpha.Success.V1, _ => true, TestFunc.Takes.Alpha.Returns.Success.Beta1, _ => TestResult.Beta.Success.V2, TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, _ => false, TestFunc.Takes.Alpha.Returns.Success.Beta1, _ => TestResult.Beta.Success.V2, TestValues.Beta2, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, _ => true, TestFunc.Takes.Alpha.Returns.Failure.Beta, _ => TestResult.Beta.Success.V2, TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
        { TestResult.Alpha.Success.V1, _ => false, TestFunc.Takes.Alpha.Returns.Success.Beta1, TestFunc.Takes.Alpha.Returns.Failure.Beta, TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
        { TestResult.Alpha.Failure, _ => true, TestFunc.Takes.Alpha.Returns.Success.Beta1, _ => TestResult.Beta.Success.V2, TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
    };

    [Theory, MemberData(nameof(TestData_FuncValueBoolCondition_ResultMappers))]
    public void ValueResult_Fork_FuncValueBoolCondition_ResultMappers(
        Result<Types.Alpha> first,
        Func<Types.Alpha, bool> condition,
        Func<Types.Alpha, Result<Types.Beta>> onTrue,
        Func<Types.Alpha, Result<Types.Beta>> onFalse,
        Types.Beta expectedValue,
        Action<Result<Types.Beta>, Types.Beta> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<TValue, bool> condition with mixed mappers
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, bool>, Func<Types.Alpha, Types.Beta>, Func<Types.Alpha, Result<Types.Beta>>, Types.Beta, Action<Result<Types.Beta>, Types.Beta>> TestData_FuncValueBoolCondition_MixedMappers => new()
    {
        { TestResult.Alpha.Success.V1, _ => true, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestResult.Beta.Success.V2, TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, _ => false, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestResult.Beta.Success.V2, TestValues.Beta2, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Success.V1, _ => false, TestFunc.Takes.Alpha.Returns.Beta1, TestFunc.Takes.Alpha.Returns.Failure.Beta, TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
        { TestResult.Alpha.Failure, _ => true, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestResult.Beta.Success.V2, TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
    };

    [Theory, MemberData(nameof(TestData_FuncValueBoolCondition_MixedMappers))]
    public void ValueResult_Fork_FuncValueBoolCondition_MixedMappers(
        Result<Types.Alpha> first,
        Func<Types.Alpha, bool> condition,
        Func<Types.Alpha, Types.Beta> onTrue,
        Func<Types.Alpha, Result<Types.Beta>> onFalse,
        Types.Beta expectedValue,
        Action<Result<Types.Beta>, Types.Beta> validate)
    {
        var result = first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
