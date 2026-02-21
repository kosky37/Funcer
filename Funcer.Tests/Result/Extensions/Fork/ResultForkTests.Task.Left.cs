using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Fork;

using Result = Funcer.Result;

public class ResultForkTests_Task_Left
{
    // Test data for bool condition with value mappers (Task left, sync mappers)
    public static TheoryData<Task<Result>, bool, Func<Types.Alpha>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ValueMappers => new()
    {
        { TestResult.Async.Success, true, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, false, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Async.Failure, true, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ValueMappers))]
    public async Task ResultTask_Fork_BoolCondition_ValueMappers_Sync(
        Task<Result> first,
        bool condition,
        Func<Types.Alpha> onTrue,
        Func<Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for bool condition with Result mappers (Task left, sync mappers)
    public static TheoryData<Task<Result>, bool, Func<Result<Types.Alpha>>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_BoolCondition_ResultMappers => new()
    {
        { TestResult.Async.Success, true, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, false, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, true, TestFunc.Returns.Failure.Alpha, () => TestResult.Alpha.Success.V2, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Async.Failure, false, TestFunc.Returns.Success.Alpha1, () => TestResult.Alpha.Success.V2, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_BoolCondition_ResultMappers))]
    public async Task ResultTask_Fork_BoolCondition_ResultMappers_Sync(
        Task<Result> first,
        bool condition,
        Func<Result<Types.Alpha>> onTrue,
        Func<Result<Types.Alpha>> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }

    // Test data for Func<bool> condition
    public static TheoryData<Task<Result>, Func<bool>, Func<Types.Alpha>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData_FuncBoolCondition_ValueMappers => new()
    {
        { TestResult.Async.Success, TestFunc.Returns.True, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, TestFunc.Returns.False, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Async.Failure, TestFunc.Returns.True, TestFunc.Returns.Alpha1, () => TestValues.Alpha2, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData_FuncBoolCondition_ValueMappers))]
    public async Task ResultTask_Fork_FuncBoolCondition_ValueMappers_Sync(
        Task<Result> first,
        Func<bool> condition,
        Func<Types.Alpha> onTrue,
        Func<Types.Alpha> onFalse,
        Types.Alpha expectedValue,
        Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first.Fork(condition, onTrue, onFalse);
        validate(result, expectedValue);
    }
}
