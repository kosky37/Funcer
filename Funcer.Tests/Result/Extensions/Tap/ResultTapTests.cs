using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Tap;

using Result = Funcer.Result;

public class ResultTapTests
{
    public static TheoryData<Result, Func<Result>, Action<Result>> TestData1 => new()
    {
        { TestResult.Success, Functions.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Success, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Failure, Functions.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Failure, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public void Result_Tap_FuncResult(Result first, Func<Result> next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Result, Func<Result<Types.Alpha>>, Action<Result>> TestData2 => new()
    {
        { TestResult.Success, Functions.Returns.Success.Alpha1, Assertions.ResultSuccess },
        { TestResult.Success, Functions.Returns.Failure.Alpha, Assertions.ResultFailure },
        { TestResult.Failure, Functions.Returns.Success.Alpha1, Assertions.ResultFailure },
        { TestResult.Failure, Functions.Returns.Failure.Alpha, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public void Result_Tap_FuncValueResult(Result first, Func<Result<Types.Alpha>> next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Result, Action, Action<Result>> TestData3 => new()
    {
        { TestResult.Success, Functions.Returns.Nothing, Assertions.ResultSuccess },
        { TestResult.Failure, Functions.Returns.Nothing, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public void Result_Tap_Action(Result first, Action next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Result, Func<Types.Alpha>, Action<Result>> TestData4 => new()
    {
        { TestResult.Success, Functions.Returns.Alpha1, Assertions.ResultSuccess },
        { TestResult.Failure, Functions.Returns.Alpha1, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public void Result_Tap_FuncAlpha(Result first, Func<Types.Alpha> next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
}