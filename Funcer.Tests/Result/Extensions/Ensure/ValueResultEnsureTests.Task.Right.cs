using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

public class ValueResultEnsureTests_Task_Right
{
    public static TheoryData<Result<Types.Alpha>, Func<Task<bool>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.True, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.False, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.True, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.False, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResult_Ensure_ConditionTask(Result<Types.Alpha> first, Func<Task<bool>> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Task<bool>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        {
            TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha1,
            Assertions.ValueResultSuccess
        },
        {
            TestResult.Alpha.Success.V2, AsyncFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha2,
            Assertions.ValueResultSuccess
        },
        {
            TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha1,
            Assertions.ValueResultFailure
        },
        {
            TestResult.Alpha.Success.V2, AsyncFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha2,
            Assertions.ValueResultFailure
        },
        {
            TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha1, Assertions.ValueResultFailure
        },
        {
            TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha1,
            Assertions.ValueResultFailure
        }
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResult_Ensure_ConditionTaskWithParameter(Result<Types.Alpha> first, Func<Types.Alpha, Task<bool>> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, expectedValue);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Task<Result<bool>>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.BoolSuccessTrue, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.BoolSuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.BoolFailure, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.BoolSuccessTrue, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.BoolSuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.BoolFailure, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResult_Ensure_ResultBoolConditionTask(Result<Types.Alpha> first, Func<Task<Result<bool>>> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Task<Result<bool>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.BoolSuccessTrue, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.BoolSuccessFalse, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.BoolFailure, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.BoolSuccessTrue, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.BoolSuccessFalse, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.BoolFailure, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResult_Ensure_ResultBoolConditionTaskWithParameter(Result<Types.Alpha> first, Func<Types.Alpha, Task<Result<bool>>> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, expectedValue);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Task<bool>>, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData5 => new()
    {
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.True, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.False, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.True, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.False, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResult_Ensure_ConditionTaskWithErrorFactory(Result<Types.Alpha> first, Func<Task<bool>> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Task<bool>>, Func<Types.Alpha, ErrorMessage>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData6 => new()
    {
        { TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.IsTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.IsFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.IsTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.IsFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResult_Ensure_ConditionTaskWithParameterAndErrorFactory(Result<Types.Alpha> first, Func<Types.Alpha, Task<bool>> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, expectedValue);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Task<Result<bool>>>, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData7 => new()
    {
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.BoolSuccessTrue, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.BoolSuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.BoolFailure, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.BoolSuccessTrue, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.BoolSuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.BoolFailure, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResult_Ensure_ResultBoolConditionTaskWithErrorFactory(Result<Types.Alpha> first, Func<Task<Result<bool>>> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Task<Result<bool>>>, Func<Types.Alpha, ErrorMessage>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.BoolSuccessTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.BoolSuccessFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, AsyncFunc.Takes.Alpha.Returns.BoolFailure, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.BoolSuccessTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.BoolSuccessFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Takes.Alpha.Returns.BoolFailure, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResult_Ensure_ResultBoolConditionTaskWithParameterAndErrorFactory(Result<Types.Alpha> first, Func<Types.Alpha, Task<Result<bool>>> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, expectedValue);
    }
}