using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Tap;

using Result = Funcer.Result;

public class ResultTapTests_Task
{
    public static TheoryData<Task<Result>, Func<Task<Result>>, Action<Result>> TestData1 => new()
    {
        { TestResult.Async.Success, Tasks.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Async.Success, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, Tasks.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
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
        { TestResult.Async.Success, Tasks.Returns.Success.Alpha1, Assertions.ResultSuccess },
        { TestResult.Async.Success, Tasks.Returns.Failure.Alpha, Assertions.ResultFailure },
        { TestResult.Async.Failure, Tasks.Returns.Success.Alpha1, Assertions.ResultFailure },
        { TestResult.Async.Failure, Tasks.Returns.Failure.Alpha, Assertions.ResultFailure },
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
        { TestResult.Async.Success, Tasks.Returns.Nothing, Assertions.ResultSuccess },
        { TestResult.Async.Failure, Tasks.Returns.Nothing, Assertions.ResultFailure }
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
        { TestResult.Async.Success, Tasks.Returns.Alpha1, Assertions.ResultSuccess },
        { TestResult.Async.Failure, Tasks.Returns.Alpha1, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ResultTask_Tap_ValueTask(Task<Result> first, Func<Task<Types.Alpha>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
}