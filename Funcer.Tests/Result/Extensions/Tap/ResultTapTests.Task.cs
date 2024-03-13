using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Tap;

using Result = Funcer.Result;

public class ResultTapTests_Task
{
    public static TheoryData<Task<Result>, Func<Task<Result>>, Action<Result>> TestData1 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Async.Success, AsyncFunc.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_Tap_ResultTask(Task<Result> first, Func<Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Func<Task<Result<Types.Alpha>>>, Action<Result>> TestData2 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.Success.Alpha1, Assertions.ResultSuccess },
        { TestResult.Async.Success, AsyncFunc.Returns.Failure.Alpha, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.Success.Alpha1, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.Failure.Alpha, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ResultTask_Tap_ValueResultTask(Task<Result> first, Func<Task<Result<Types.Alpha>>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Func<Task>, Action<Result>> TestData3 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.Void, Assertions.ResultSuccess },
        { TestResult.Async.Failure, AsyncFunc.Returns.Void, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ResultTask_Tap_Task(Task<Result> first, Func<Task> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Func<Task<Types.Alpha>>, Action<Result>> TestData4 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.Alpha1, Assertions.ResultSuccess },
        { TestResult.Async.Failure, AsyncFunc.Returns.Alpha1, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ResultTask_Tap_ValueTask(Task<Result> first, Func<Task<Types.Alpha>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
}