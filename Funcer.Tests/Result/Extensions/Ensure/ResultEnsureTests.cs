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
}