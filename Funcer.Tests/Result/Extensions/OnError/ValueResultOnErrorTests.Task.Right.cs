using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.OnError;

using Result = Funcer.Result;

public class ValueResultOnErrorTests_Task_Right
{
    public static TheoryData<Result<Types.Alpha>, string, Func<IEnumerable<ErrorMessage>, Task<Result<Types.Alpha>>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, async _ => { await Task.CompletedTask; return TestResult.Alpha.Success.V1; }, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, async _ => { await Task.CompletedTask; return TestResult.Alpha.Success.V1; }, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", async _ => { await Task.CompletedTask; return TestResult.Alpha.Success.V1; }, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResult_OnError_Func_ValueResult_With_Errors_Task(Result<Types.Alpha> first, string errorType, Func<IEnumerable<ErrorMessage>, Task<Result<Types.Alpha>>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<Task<Result<Types.Alpha>>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, async () => { await Task.CompletedTask; return TestResult.Alpha.Success.V1; }, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, async () => { await Task.CompletedTask; return TestResult.Alpha.Success.V1; }, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", async () => { await Task.CompletedTask; return TestResult.Alpha.Success.V1; }, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResult_OnError_Func_ValueResult_Task(Result<Types.Alpha> first, string errorType, Func<Task<Result<Types.Alpha>>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<IEnumerable<ErrorMessage>, Task<Types.Alpha>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, async _ => { await Task.CompletedTask; return TestValues.Alpha1; }, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, async _ => { await Task.CompletedTask; return TestValues.Alpha2; }, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", async _ => { await Task.CompletedTask; return TestValues.Alpha1; }, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResult_OnError_Func_TValue_With_Errors_Task(Result<Types.Alpha> first, string errorType, Func<IEnumerable<ErrorMessage>, Task<Types.Alpha>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<Task<Types.Alpha>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, async () => { await Task.CompletedTask; return TestValues.Alpha1; }, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, async () => { await Task.CompletedTask; return TestValues.Alpha2; }, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", async () => { await Task.CompletedTask; return TestValues.Alpha1; }, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResult_OnError_Func_TValue_Task(Result<Types.Alpha> first, string errorType, Func<Task<Types.Alpha>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<IEnumerable<ErrorMessage>, Task>, Action<Result>> TestData5 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, async _ => { await Task.CompletedTask; }, Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, async _ => { await Task.CompletedTask; }, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", async _ => { await Task.CompletedTask; }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResult_OnError_Action_With_Errors_Task_Returns_Result(Result<Types.Alpha> first, string errorType, Func<IEnumerable<ErrorMessage>, Task> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<Task>, Action<Result>> TestData6 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, async () => { await Task.CompletedTask; }, Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, async () => { await Task.CompletedTask; }, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", async () => { await Task.CompletedTask; }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResult_OnError_Action_Task_Returns_Result(Result<Types.Alpha> first, string errorType, Func<Task> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<IEnumerable<ErrorMessage>, Task<Result>>, Action<Result>> TestData7 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, async _ => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, async _ => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", async _ => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResult_OnError_Func_Result_With_Errors_Task(Result<Types.Alpha> first, string errorType, Func<IEnumerable<ErrorMessage>, Task<Result>> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<Task<Result>>, Action<Result>> TestData8 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, async () => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, async () => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", async () => { await Task.CompletedTask; return Result.Success(); }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResult_OnError_Func_Result_Task(Result<Types.Alpha> first, string errorType, Func<Task<Result>> onError, Action<Result> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result);
    }
}
