using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Tap;

using Result = Funcer.Result;

public class ResultTapTests_Task_Right
{
    public static TheoryData<Result, Func<Task<Result>>, Action<Result>> TestData1 => new()
    {
        { TestResult.Success, AsyncFunc.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Success, AsyncFunc.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Failure, AsyncFunc.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Failure, AsyncFunc.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task Result_Tap_ResultTask(Result first, Func<Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Result, Func<Task<Result<Types.Alpha>>>, Action<Result>> TestData2 => new()
    {
        { TestResult.Success, AsyncFunc.Returns.Success.Alpha1, Assertions.ResultSuccess },
        { TestResult.Success, AsyncFunc.Returns.Failure.Alpha, Assertions.ResultFailure },
        { TestResult.Failure, AsyncFunc.Returns.Success.Alpha1, Assertions.ResultFailure },
        { TestResult.Failure, AsyncFunc.Returns.Failure.Alpha, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task Result_Tap_ValueResultTask(Result first, Func<Task<Result<Types.Alpha>>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Result, Func<Task>, Action<Result>> TestData3 => new()
    {
        { TestResult.Success, AsyncFunc.Returns.Void, Assertions.ResultSuccess },
        { TestResult.Failure, AsyncFunc.Returns.Void, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task Result_Tap_Task(Result first, Func<Task> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Result, Func<Task<Types.Alpha>>, Action<Result>> TestData4 => new()
    {
        { TestResult.Success, AsyncFunc.Returns.Alpha1, Assertions.ResultSuccess },
        { TestResult.Failure, AsyncFunc.Returns.Alpha1, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task Result_Tap_ValueTask(Result first, Func<Task<Types.Alpha>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
}