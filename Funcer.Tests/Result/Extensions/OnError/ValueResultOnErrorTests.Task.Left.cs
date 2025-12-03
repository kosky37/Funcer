using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.OnError;

using Result = Funcer.Result;

public class ValueResultOnErrorTests_Task_Left
{
    public static TheoryData<Task<Result<Types.Alpha>>, string, Func<IEnumerable<ErrorMessage>, Result<Types.Alpha>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestValues.Error.Type, _ => TestResult.Alpha.Success.V1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestValues.Error.Type, _ => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, "DifferentErrorType", _ => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_OnError_Func_ValueResult_With_Errors(Task<Result<Types.Alpha>> first, string errorType, Func<IEnumerable<ErrorMessage>, Result<Types.Alpha>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, string, Func<Result<Types.Alpha>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestValues.Error.Type, () => TestResult.Alpha.Success.V1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestValues.Error.Type, () => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, "DifferentErrorType", () => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_OnError_Func_ValueResult(Task<Result<Types.Alpha>> first, string errorType, Func<Result<Types.Alpha>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, string, Func<IEnumerable<ErrorMessage>, Types.Alpha>, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestValues.Error.Type, _ => TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestValues.Error.Type, _ => TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, "DifferentErrorType", _ => TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask_OnError_Func_TValue_With_Errors(Task<Result<Types.Alpha>> first, string errorType, Func<IEnumerable<ErrorMessage>, Types.Alpha> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, string, Func<Types.Alpha>, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestValues.Error.Type, () => TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestValues.Error.Type, () => TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, "DifferentErrorType", () => TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResultTask_OnError_Func_TValue(Task<Result<Types.Alpha>> first, string errorType, Func<Types.Alpha> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, string, Func<IEnumerable<ErrorMessage>, Result<Types.Beta>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData5 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestValues.Error.Type, _ => TestResult.Beta.Success.V1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestValues.Error.Type, _ => TestResult.Beta.Success.V1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, "DifferentErrorType", _ => TestResult.Beta.Success.V1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResultTask_OnError_Func_ValueResult_With_Errors_DifferentType(Task<Result<Types.Alpha>> first, string errorType, Func<IEnumerable<ErrorMessage>, Result<Types.Beta>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, string, Func<Result<Types.Beta>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData6 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestValues.Error.Type, () => TestResult.Beta.Success.V1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestValues.Error.Type, () => TestResult.Beta.Success.V1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, "DifferentErrorType", () => TestResult.Beta.Success.V1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResultTask_OnError_Func_ValueResult_DifferentType(Task<Result<Types.Alpha>> first, string errorType, Func<Result<Types.Beta>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, string, Func<IEnumerable<ErrorMessage>, Types.Beta>, Action<Result<Types.Alpha>, Types.Alpha>> TestData7 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestValues.Error.Type, _ => TestValues.Beta1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestValues.Error.Type, _ => TestValues.Beta2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, "DifferentErrorType", _ => TestValues.Beta1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResultTask_OnError_Func_TValue_With_Errors_DifferentType(Task<Result<Types.Alpha>> first, string errorType, Func<IEnumerable<ErrorMessage>, Types.Beta> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, string, Func<Types.Beta>, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestValues.Error.Type, () => TestValues.Beta1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestValues.Error.Type, () => TestValues.Beta2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, "DifferentErrorType", () => TestValues.Beta1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResultTask_OnError_Func_TValue_DifferentType(Task<Result<Types.Alpha>> first, string errorType, Func<Types.Beta> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
}
