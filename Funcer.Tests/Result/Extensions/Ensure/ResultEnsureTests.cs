using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Ensure;

using Result = Funcer.Result;

public class ResultEnsureTests
{
    public static TheoryData<Result, bool, Action<Result>> TestData1 => new()
    {
        { TestResult.Success, true, Assertions.ResultSuccess },
        { TestResult.Success, false, Assertions.ResultFailure },
        { TestResult.Failure, true, Assertions.ResultFailure },
        { TestResult.Failure, false, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData1))]
    public void Result_Ensure_Condition(Result first, bool condition, Action<Result> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }
    
    public static TheoryData<Result, Func<bool>, Action<Result>> TestData2 => new()
    {
        { TestResult.Success, TestFunc.Returns.True, Assertions.ResultSuccess },
        { TestResult.Success, TestFunc.Returns.False, Assertions.ResultFailure },
        { TestResult.Failure, TestFunc.Returns.True, Assertions.ResultFailure },
        { TestResult.Failure, TestFunc.Returns.False, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData2))]
    public void Result_Ensure_ConditionFunction(Result first, Func<bool> condition, Action<Result> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }

    public static TheoryData<Result, Result<bool>, Action<Result>> TestData3 => new()
    {
        { TestResult.Success, TestResult.Bool.SuccessTrue, Assertions.ResultSuccess },
        { TestResult.Success, TestResult.Bool.SuccessFalse, Assertions.ResultFailure },
        { TestResult.Success, TestResult.Bool.Failure, Assertions.ResultFailure },
        { TestResult.Failure, TestResult.Bool.SuccessTrue, Assertions.ResultFailure },
        { TestResult.Failure, TestResult.Bool.SuccessFalse, Assertions.ResultFailure },
        { TestResult.Failure, TestResult.Bool.Failure, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public void Result_Ensure_ResultBoolCondition(Result first, Result<bool> condition, Action<Result> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }

    public static TheoryData<Result, Func<Result<bool>>, Action<Result>> TestData4 => new()
    {
        { TestResult.Success, TestFunc.Returns.BoolSuccessTrue, Assertions.ResultSuccess },
        { TestResult.Success, TestFunc.Returns.BoolSuccessFalse, Assertions.ResultFailure },
        { TestResult.Success, TestFunc.Returns.BoolFailure, Assertions.ResultFailure },
        { TestResult.Failure, TestFunc.Returns.BoolSuccessTrue, Assertions.ResultFailure },
        { TestResult.Failure, TestFunc.Returns.BoolSuccessFalse, Assertions.ResultFailure },
        { TestResult.Failure, TestFunc.Returns.BoolFailure, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public void Result_Ensure_ResultBoolConditionFunction(Result first, Func<Result<bool>> condition, Action<Result> validate)
    {
        var result = first
            .Ensure(condition, TestValues.Error);

        validate(result);
    }
}