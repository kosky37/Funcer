using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

public class ValueResultEnsureTests_Task_Left
{
    public static TheoryData<Task<Result<Types.Alpha>>, bool, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Async.Success.V1, true, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, false, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, true, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, false, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_Ensure_Condition(Task<Result<Types.Alpha>> first, bool condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<bool>, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.True, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.False, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.True, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.False, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_Ensure_ConditionFunction(Task<Result<Types.Alpha>> first, Func<bool> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, bool>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V2, TestFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Success.V2, TestFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask_Ensure_ConditionFunctionWithParameter(Task<Result<Types.Alpha>> first, Func<Types.Alpha, bool> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, expectedValue);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Result<bool>, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestResult.Bool.SuccessTrue, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestResult.Bool.SuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Success.V1, TestResult.Bool.Failure, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestResult.Bool.SuccessTrue, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestResult.Bool.SuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestResult.Bool.Failure, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResultTask_Ensure_ResultBoolCondition(Task<Result<Types.Alpha>> first, Result<bool> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result<bool>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData5 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.BoolSuccessTrue, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.BoolSuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.BoolFailure, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.BoolSuccessTrue, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.BoolSuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.BoolFailure, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResultTask_Ensure_ResultBoolConditionFunction(Task<Result<Types.Alpha>> first, Func<Result<bool>> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Result<bool>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData6 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.BoolSuccessTrue, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.BoolSuccessFalse, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.BoolFailure, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.BoolSuccessTrue, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.BoolSuccessFalse, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.BoolFailure, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResultTask_Ensure_ResultBoolConditionFunctionWithParameter(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result<bool>> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, TestValues.Error);

        validate(result, expectedValue);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, bool, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData7 => new()
    {
        { TestResult.Alpha.Async.Success.V1, true, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, false, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, true, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, false, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResultTask_Ensure_ConditionWithErrorFactory(Task<Result<Types.Alpha>> first, bool condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Func<bool>, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.True, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.False, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.True, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.False, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResultTask_Ensure_ConditionFunctionWithErrorFactory(Task<Result<Types.Alpha>> first, Func<bool> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, bool>, Func<Types.Alpha, ErrorMessage>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData9 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.IsTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.IsFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.IsTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.IsFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData9))]
    public async Task ValueResultTask_Ensure_ConditionFunctionWithParameterAndErrorFactory(Task<Result<Types.Alpha>> first, Func<Types.Alpha, bool> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, expectedValue);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Result<bool>, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData10 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestResult.Bool.SuccessTrue, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestResult.Bool.SuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Success.V1, TestResult.Bool.Failure, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestResult.Bool.SuccessTrue, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestResult.Bool.SuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestResult.Bool.Failure, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData10))]
    public async Task ValueResultTask_Ensure_ResultBoolConditionWithErrorFactory(Task<Result<Types.Alpha>> first, Result<bool> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result<bool>>, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData11 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.BoolSuccessTrue, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.BoolSuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.BoolFailure, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.BoolSuccessTrue, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.BoolSuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.BoolFailure, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData11))]
    public async Task ValueResultTask_Ensure_ResultBoolConditionFunctionWithErrorFactory(Task<Result<Types.Alpha>> first, Func<Result<bool>> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Result<bool>>, Func<Types.Alpha, ErrorMessage>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData12 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.BoolSuccessTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.BoolSuccessFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.BoolFailure, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.BoolSuccessTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.BoolSuccessFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.BoolFailure, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData12))]
    public async Task ValueResultTask_Ensure_ResultBoolConditionFunctionWithParameterAndErrorFactory(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result<bool>> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, errorFactory);

        validate(result, expectedValue);
    }
}