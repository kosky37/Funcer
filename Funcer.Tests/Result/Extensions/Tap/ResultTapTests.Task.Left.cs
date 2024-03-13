using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Tap;

using Result = Funcer.Result;

public class ResultTapTests_Task_Left
{
    public static TheoryData<Task<Result>,  Func<Result>, Action<Result>> TestData1 => new()
    {
        { TestResult.Async.Success, TestFunc.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Async.Success, TestFunc.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestFunc.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestFunc.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_Tap_ResultFunction(Task<Result> first,  Func<Result> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Func<Result<Types.Alpha>>, Action<Result>> TestData2 => new()
    {
        { TestResult.Async.Success, TestFunc.Returns.Success.Alpha1, Assertions.ResultSuccess },
        { TestResult.Async.Success, TestFunc.Returns.Failure.Alpha, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestFunc.Returns.Success.Alpha1, Assertions.ResultFailure },
        { TestResult.Async.Failure, TestFunc.Returns.Failure.Alpha, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ResultTask_Tap_ValueResultFunction(Task<Result> first, Func<Result<Types.Alpha>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Action, Action<Result>> TestData3 => new()
    {
        { TestResult.Async.Success, TestFunc.Returns.Void, Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestFunc.Returns.Void, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ResultTask_Tap_Action(Task<Result> first, Action next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Func<Types.Alpha>, Action<Result>> TestData4 => new()
    {
        { TestResult.Async.Success, TestFunc.Returns.Alpha1, Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestFunc.Returns.Alpha1, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ResultTask_Tap_Function(Task<Result> first, Func<Types.Alpha> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
}