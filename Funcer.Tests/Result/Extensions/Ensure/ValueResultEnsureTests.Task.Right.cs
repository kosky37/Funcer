using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

public class ValueResultEnsureTests_Task_Right
{
    public static TheoryData<Result<Types.Alpha>, Func<Task<bool>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Success.V1, Tasks.Returns.True, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, Tasks.Returns.False, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Returns.True, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Returns.False, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResult_Ensure_ConditionTask(Result<Types.Alpha> first, Func<Task<bool>> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result, Values.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Task<bool>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        {
            TestResult.Alpha.Success.V1, Tasks.Takes.Alpha.Returns.IsTrue, Values.Alpha1,
            Assertions.ValueResultSuccess
        },
        {
            TestResult.Alpha.Success.V2, Tasks.Takes.Alpha.Returns.IsFalse, Values.Alpha2,
            Assertions.ValueResultSuccess
        },
        {
            TestResult.Alpha.Success.V1, Tasks.Takes.Alpha.Returns.IsFalse, Values.Alpha1,
            Assertions.ValueResultFailure
        },
        {
            TestResult.Alpha.Success.V2, Tasks.Takes.Alpha.Returns.IsTrue, Values.Alpha2,
            Assertions.ValueResultFailure
        },
        {
            TestResult.Alpha.Failure, Tasks.Takes.Alpha.Returns.IsTrue, Values.Alpha1, Assertions.ValueResultFailure
        },
        {
            TestResult.Alpha.Failure, Tasks.Takes.Alpha.Returns.IsFalse, Values.Alpha1,
            Assertions.ValueResultFailure
        }
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResult_Ensure_ConditionTaskWithParameter(Result<Types.Alpha> first, Func<Types.Alpha, Task<bool>> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result, expectedValue);
    }
}