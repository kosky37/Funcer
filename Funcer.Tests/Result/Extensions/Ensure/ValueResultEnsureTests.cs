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
}