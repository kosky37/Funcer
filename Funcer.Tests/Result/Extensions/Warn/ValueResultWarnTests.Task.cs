using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Warn;

public class ValueResultWarnTests_Task
{
    public static TheoryData<Task<Result<Types.Alpha>>, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage>> TestData => new()
    {
        { TestResult.Alpha.Async.Success.V1, Assertions.ValueResultSuccessWithWarning },
        { TestResult.Alpha.Async.Failure, Assertions.ValueResultFailureWithoutWarnings }
    };
    
    [Theory, MemberData(nameof(TestData))]
    public async Task Warn_AddsWarningToValueResult(Task<Result<Types.Alpha>> initial, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage> validate)
    {
        var result = await initial
            .Warn(TestValues.Warning);
        
        validate(result, TestValues.Alpha1, TestValues.Warning);
    }
}