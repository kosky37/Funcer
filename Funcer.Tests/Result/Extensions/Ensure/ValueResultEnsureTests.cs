using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

public class ValueResultEnsureTests
{
    public static TheoryData<Result<Types.Alpha>, bool, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Success.V1, true, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, false, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, true, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, false, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public void ValueResult_Ensure_Condition(Result<Types.Alpha> first, bool condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<bool>, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Returns.True, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestFunc.Returns.False, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.True, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.False, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData2))]
    public void ValueResult_Ensure_ConditionFunction(Result<Types.Alpha> first, Func<bool> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, bool>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V2, TestFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V2, TestFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.IsTrue, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.IsFalse, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public void ValueResult_Ensure_ConditionFunctionWithParameter(Result<Types.Alpha> first, Func<Types.Alpha, bool> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result, expectedValue);
    }

    public static TheoryData<Result<Types.Alpha>, Result<bool>, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Success.V1, TestResult.Bool.SuccessTrue, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestResult.Bool.SuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, TestResult.Bool.Failure, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestResult.Bool.SuccessTrue, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestResult.Bool.SuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestResult.Bool.Failure, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public void ValueResult_Ensure_ResultBoolCondition(Result<Types.Alpha> first, Result<bool> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Result<bool>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData5 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Returns.BoolSuccessTrue, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestFunc.Returns.BoolSuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, TestFunc.Returns.BoolFailure, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.BoolSuccessTrue, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.BoolSuccessFalse, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.BoolFailure, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData5))]
    public void ValueResult_Ensure_ResultBoolConditionFunction(Result<Types.Alpha> first, Func<Result<bool>> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Result<bool>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData6 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.BoolSuccessTrue, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.BoolSuccessFalse, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.BoolFailure, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.BoolSuccessTrue, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.BoolSuccessFalse, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.BoolFailure, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public void ValueResult_Ensure_ResultBoolConditionFunctionWithParameter(Result<Types.Alpha> first, Func<Types.Alpha, Result<bool>> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result, expectedValue);
    }

    public static TheoryData<Result<Types.Alpha>, bool, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData7 => new()
    {
        { TestResult.Alpha.Success.V1, true, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, false, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, true, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, false, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public void ValueResult_Ensure_ConditionWithErrorFactory(Result<Types.Alpha> first, bool condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<bool>, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Returns.True, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestFunc.Returns.False, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.True, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.False, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public void ValueResult_Ensure_ConditionFunctionWithErrorFactory(Result<Types.Alpha> first, Func<bool> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, bool>, Func<Types.Alpha, ErrorMessage>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData9 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.IsTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.IsFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.IsTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.IsFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData9))]
    public void ValueResult_Ensure_ConditionFunctionWithParameterAndErrorFactory(Result<Types.Alpha> first, Func<Types.Alpha, bool> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, errorFactory);

        validate(result, expectedValue);
    }

    public static TheoryData<Result<Types.Alpha>, Result<bool>, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData10 => new()
    {
        { TestResult.Alpha.Success.V1, TestResult.Bool.SuccessTrue, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestResult.Bool.SuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, TestResult.Bool.Failure, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestResult.Bool.SuccessTrue, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestResult.Bool.SuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestResult.Bool.Failure, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData10))]
    public void ValueResult_Ensure_ResultBoolConditionWithErrorFactory(Result<Types.Alpha> first, Result<bool> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Result<bool>>, Func<Types.Alpha, ErrorMessage>, Action<Result<Types.Alpha>, Types.Alpha>> TestData11 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Returns.BoolSuccessTrue, _ => TestValues.Error, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestFunc.Returns.BoolSuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, TestFunc.Returns.BoolFailure, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.BoolSuccessTrue, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.BoolSuccessFalse, _ => TestValues.Error, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Returns.BoolFailure, _ => TestValues.Error, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData11))]
    public void ValueResult_Ensure_ResultBoolConditionFunctionWithErrorFactory(Result<Types.Alpha> first, Func<Result<bool>> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, errorFactory);

        validate(result, TestValues.Alpha1);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Result<bool>>, Func<Types.Alpha, ErrorMessage>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData12 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.BoolSuccessTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.BoolSuccessFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.BoolFailure, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.BoolSuccessTrue, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.BoolSuccessFalse, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.BoolFailure, _ => TestValues.Error, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData12))]
    public void ValueResult_Ensure_ResultBoolConditionFunctionWithParameterAndErrorFactory(Result<Types.Alpha> first, Func<Types.Alpha, Result<bool>> condition, Func<Types.Alpha, ErrorMessage> errorFactory, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, errorFactory);

        validate(result, expectedValue);
    }
}