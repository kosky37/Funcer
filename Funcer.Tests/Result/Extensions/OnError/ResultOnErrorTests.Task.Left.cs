using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.OnError;

using Result = Funcer.Result;

public class ResultOnErrorTests_Task_Left
{
    public static TheoryData<Task<Result>, string, Action<IEnumerable<ErrorMessage>>, Action<Result>> TestData1 => new()
    {
        { TestResult.Async.Success, TestValues.Error.Type, _ => { }, Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestValues.Error.Type, _ => { }, Assertions.ResultFailure },
        { TestResult.Async.Failure, "DifferentErrorType", _ => { }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_OnError_Action_With_Errors(Task<Result> first, string errorType, Action<IEnumerable<ErrorMessage>> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, string, Action, Action<Result>> TestData2 => new()
    {
        { TestResult.Async.Success, TestValues.Error.Type, () => { }, Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestValues.Error.Type, () => { }, Assertions.ResultFailure },
        { TestResult.Async.Failure, "DifferentErrorType", () => { }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ResultTask_OnError_Action(Task<Result> first, string errorType, Action onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, string, Func<IEnumerable<ErrorMessage>, Result>, Action<Result>> TestData3 => new()
    {
        { TestResult.Async.Success, TestValues.Error.Type, _ => Result.Success(), Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestValues.Error.Type, _ => Result.Success(), Assertions.ResultFailure },
        { TestResult.Async.Failure, "DifferentErrorType", _ => Result.Success(), Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ResultTask_OnError_Func_Result_With_Errors(Task<Result> first, string errorType, Func<IEnumerable<ErrorMessage>, Result> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, string, Func<Result>, Action<Result>> TestData4 => new()
    {
        { TestResult.Async.Success, TestValues.Error.Type, () => Result.Success(), Assertions.ResultSuccess },
        { TestResult.Async.Failure, TestValues.Error.Type, () => Result.Success(), Assertions.ResultFailure },
        { TestResult.Async.Failure, "DifferentErrorType", () => Result.Success(), Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ResultTask_OnError_Func_Result(Task<Result> first, string errorType, Func<Result> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
}
