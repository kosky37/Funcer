using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Warn;

public class ResultWarnTests_Task
{
    public static TheoryData<Task<Funcer.Result>, Action<Funcer.Result, IResultMessage>> TestData => new()
    {
        { TestResult.Async.Success, Assertions.ResultSuccessWithWarning },
        { TestResult.Async.Failure, Assertions.ResultFailureWithoutWarnings }
    };
    
    [Theory, MemberData(nameof(TestData))]
    public async Task Warn_AddsWarningToResult(Task<Funcer.Result> initial, Action<Funcer.Result, IResultMessage> validate)
    {
        var result = await initial
            .Warn(TestValues.Warning);
        
        validate(result, TestValues.Warning);
    }
}