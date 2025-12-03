using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.OnError;

using Result = Funcer.Result;

public class ResultOnErrorTests
{
    public static TheoryData<Result, string, Action<IEnumerable<ErrorMessage>>, Action<Result>> TestData1 => new()
    {
        { TestResult.Success, TestValues.Error.Type, _ => { }, Assertions.ResultSuccess },
        { TestResult.Failure, TestValues.Error.Type, _ => { }, Assertions.ResultFailure },
        { TestResult.Failure, "DifferentErrorType", _ => { }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public void Result_OnError_Action_With_Errors(Result first, string errorType, Action<IEnumerable<ErrorMessage>> onError, Action<Result> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Result, string, Action, Action<Result>> TestData2 => new()
    {
        { TestResult.Success, TestValues.Error.Type, () => { }, Assertions.ResultSuccess },
        { TestResult.Failure, TestValues.Error.Type, () => { }, Assertions.ResultFailure },
        { TestResult.Failure, "DifferentErrorType", () => { }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public void Result_OnError_Action(Result first, string errorType, Action onError, Action<Result> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Result, string, Func<IEnumerable<ErrorMessage>, Result>, Action<Result>> TestData3 => new()
    {
        { TestResult.Success, TestValues.Error.Type, _ => Result.Success(), Assertions.ResultSuccess },
        { TestResult.Failure, TestValues.Error.Type, _ => Result.Success(), Assertions.ResultFailure },
        { TestResult.Failure, "DifferentErrorType", _ => Result.Success(), Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData3))]
    public void Result_OnError_Func_Result_With_Errors(Result first, string errorType, Func<IEnumerable<ErrorMessage>, Result> onError, Action<Result> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Result, string, Func<Result>, Action<Result>> TestData4 => new()
    {
        { TestResult.Success, TestValues.Error.Type, () => Result.Success(), Assertions.ResultSuccess },
        { TestResult.Failure, TestValues.Error.Type, () => Result.Success(), Assertions.ResultFailure },
        { TestResult.Failure, "DifferentErrorType", () => Result.Success(), Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData4))]
    public void Result_OnError_Func_Result(Result first, string errorType, Func<Result> onError, Action<Result> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result);
    }
}
