using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.OnError;

public class ValueResultOnErrorTests_Task_Right
{
    public static TheoryData<Result<Types.Alpha>, string, Func<Task<Result<Types.Alpha>>>, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Success.V1, TestValues.Error.Type, async () => { await Task.CompletedTask; return TestResult.Alpha.Success.V1; }, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, TestValues.Error.Type, async () => { await Task.CompletedTask; return TestResult.Alpha.Success.V1; }, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, "DifferentErrorType", async () => { await Task.CompletedTask; return TestResult.Alpha.Success.V1; }, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResult_OnError_Func_ValueResult_Task(Result<Types.Alpha> first, string errorType, Func<Task<Result<Types.Alpha>>> onError, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .OnError(errorType, onError);

        validate(result, TestValues.Alpha1);
    }
}
