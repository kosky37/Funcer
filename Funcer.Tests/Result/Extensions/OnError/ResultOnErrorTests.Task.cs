using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.OnError;

using Result = Funcer.Result;

public class ResultOnErrorTests_Task
{
    public static TheoryData<Task<Result>, string, Func<IEnumerable<ErrorMessage>, Task>, Action<Result>> TestData1 => new()
    {
        { TestResult.Async.Success, TestValues.Error.Type, async _ => { await Task.CompletedTask; }, Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestValues.Error.Type, async _ => { await Task.CompletedTask; }, Assertions.ResultFailure },
        { TestResult.Async.Failure, "DifferentErrorType", async _ => { await Task.CompletedTask; }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_OnError_Action_With_Errors_Task(Task<Result> first, string errorType, Func<IEnumerable<ErrorMessage>, Task> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, string, Func<Task>, Action<Result>> TestData2 => new()
    {
        { TestResult.Async.Success, TestValues.Error.Type, async () => { await Task.CompletedTask; }, Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestValues.Error.Type, async () => { await Task.CompletedTask; }, Assertions.ResultFailure },
        { TestResult.Async.Failure, "DifferentErrorType", async () => { await Task.CompletedTask; }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ResultTask_OnError_Action_Task(Task<Result> first, string errorType, Func<Task> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, string, Func<IEnumerable<ErrorMessage>, Task<Result>>, Action<Result>> TestData3 => new()
    {
        { TestResult.Async.Success, TestValues.Error.Type, async _ => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestValues.Error.Type, async _ => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultFailure },
        { TestResult.Async.Failure, "DifferentErrorType", async _ => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ResultTask_OnError_Func_Result_With_Errors_Task(Task<Result> first, string errorType, Func<IEnumerable<ErrorMessage>, Task<Result>> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, string, Func<Task<Result>>, Action<Result>> TestData4 => new()
    {
        { TestResult.Async.Success, TestValues.Error.Type, async () => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestValues.Error.Type, async () => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultFailure },
        { TestResult.Async.Failure, "DifferentErrorType", async () => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ResultTask_OnError_Func_Result_Task(Task<Result> first, string errorType, Func<Task<Result>> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
}
