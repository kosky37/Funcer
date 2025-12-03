using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.OnError;

public class ValueResultOnErrorTests_Task_Left
{
    public static TheoryData<Task<Result<Types.Alpha>>, string, Func<Result<Types.Alpha>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestValues.Error.Type, () => TestResult.Alpha.Success.V1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestValues.Error.Type, () => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, "DifferentErrorType", () => TestResult.Alpha.Success.V1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_OnError_Func_ValueResult(Task<Result<Types.Alpha>> first, string errorType, Func<Result<Types.Alpha>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
}
