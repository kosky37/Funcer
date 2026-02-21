using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

public class ValueResultForkTests_Task_Left
{
    // Test data for bool condition with value mappers (Task left, sync mappers)
    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Types.Beta, Types.Alpha>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ValueMappers => new()
    {
        { TestResult.Beta.Async.Success.V1, true, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, true, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ValueMappers))]
    public async Task ValueResultTask_Fork_BoolCondition_ValueMappers_Sync(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Types.Beta, Types.Alpha> onTrue,
        Func<Types.Beta, Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with Result mappers (Task left, sync mappers)
    public static TheoryData<Task<Result<Types.Beta>>, bool, Func<Types.Beta, Result<Types.Alpha>>, Func<Types.Beta, Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ResultMappers => new()
    {
        { TestResult.Beta.Async.Success.V1, true, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, true, TestFunc.Takes.Beta.Returns.Failure.Alpha, _ => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, false, TestFunc.Takes.Beta.Returns.Success.Alpha1, _ => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ResultMappers))]
    public async Task ValueResultTask_Fork_BoolCondition_ResultMappers_Sync(
        Task<Result<Types.Beta>> first,
        bool condition,
        Func<Types.Beta, Result<Types.Alpha>> onTrue,
        Func<Types.Beta, Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition with value mappers
    public static TheoryData<Task<Result<Types.Beta>>, Func<bool>, Func<Types.Beta, Types.Alpha>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ValueMappers => new()
    {
        { TestResult.Beta.Async.Success.V1, TestFunc.Returns.True, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, TestFunc.Returns.False, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, TestFunc.Returns.True, TestFunc.Takes.Beta.Returns.Alpha1, _ => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ValueMappers))]
    public async Task ValueResultTask_Fork_FuncBoolCondition_ValueMappers_Sync(
        Task<Result<Types.Beta>> first,
        Func<bool> condition,
        Func<Types.Beta, Types.Alpha> onTrue,
        Func<Types.Beta, Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<TValue, bool> condition
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, bool>, Func<Types.Alpha, Types.Beta>, Func<Types.Alpha, Types.Beta>, Types.Beta, Action<Result<Types.Beta>, Types.Beta>> TestData_FuncValueBoolCondition_ValueMappers => new()
    {
        { TestResult.Alpha.Async.Success.V1, _ => true, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestValues.Beta2, TestValues.Beta1, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Async.Success.V1, _ => false, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestValues.Beta2, TestValues.Beta2, (result, expectedValue) => result.ShouldBeSuccess(expectedValue) },
        { TestResult.Alpha.Async.Failure, _ => true, TestFunc.Takes.Alpha.Returns.Beta1, _ => TestValues.Beta2, TestValues.Beta1, (result, _) => result.ShouldBeFailure() },
    };

    [Theory, MemberData(nameof(TestData_FuncValueBoolCondition_ValueMappers))]
    public async Task ValueResultTask_Fork_FuncValueBoolCondition_ValueMappers_Sync(
        Task<Result<Types.Alpha>> first,
        Func<Types.Alpha, bool> condition,
        Func<Types.Alpha, Types.Beta> onTrue,
        Func<Types.Alpha, Types.Beta> onFalse,
        Types.Beta expectedValue,
        Action<Result<Types.Beta>, Types.Beta> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
