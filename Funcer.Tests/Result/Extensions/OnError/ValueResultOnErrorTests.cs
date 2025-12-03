using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.OnError;

using Result = Funcer.Result;

public class ValueResultOnErrorTests
{
    public static TheoryData<Result<Types.Alpha>, string, Func<IEnumerable<ErrorMessage>, Result<Types.Alpha>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, _ => TestResult.Alpha.Success.V1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, _ => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", _ => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public void ValueResult_OnError_Func_ValueResult_With_Errors(Result<Types.Alpha> first, string errorType, Func<IEnumerable<ErrorMessage>, Result<Types.Alpha>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<Result<Types.Alpha>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, () => TestResult.Alpha.Success.V1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, () => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", () => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public void ValueResult_OnError_Func_ValueResult(Result<Types.Alpha> first, string errorType, Func<Result<Types.Alpha>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<IEnumerable<ErrorMessage>, Types.Alpha>, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, _ => TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, _ => TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", _ => TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData3))]
    public void ValueResult_OnError_Func_TValue_With_Errors(Result<Types.Alpha> first, string errorType, Func<IEnumerable<ErrorMessage>, Types.Alpha> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<Types.Alpha>, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, () => TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, () => TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", () => TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData4))]
    public void ValueResult_OnError_Func_TValue(Result<Types.Alpha> first, string errorType, Func<Types.Alpha> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<IEnumerable<ErrorMessage>, Result>, Action<Result>> TestData5 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, _ => Result.Success(), Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, _ => Result.Success(), Assertions.ResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", _ => Result.Success(), Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData5))]
    public void ValueResult_OnError_Func_Result_With_Errors(Result<Types.Alpha> first, string errorType, Func<IEnumerable<ErrorMessage>, Result> onError, Action<Result> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Action<IEnumerable<ErrorMessage>>, Action<Result>> TestData6 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, _ => { }, Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, _ => { }, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", _ => { }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData6))]
    public void ValueResult_OnError_Action_With_Errors_Returns_Result(Result<Types.Alpha> first, string errorType, Action<IEnumerable<ErrorMessage>> onError, Action<Result> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Func<Result>, Action<Result>> TestData7 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, () => Result.Success(), Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, () => Result.Success(), Assertions.ResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", () => Result.Success(), Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData7))]
    public void ValueResult_OnError_Func_Result(Result<Types.Alpha> first, string errorType, Func<Result> onError, Action<Result> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result);
    }
    
    public static TheoryData<Result<Types.Alpha>, string, Action, Action<Result>> TestData8 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, () => { }, Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, () => { }, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", () => { }, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData8))]
    public void ValueResult_OnError_Action_Returns_Result(Result<Types.Alpha> first, string errorType, Action onError, Action<Result> validate)
    {
        var result = first
            .OnError(errorType, onError);

        validate(result);
    }
}
