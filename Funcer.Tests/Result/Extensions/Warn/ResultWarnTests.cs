using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Warn;

using Result = Funcer.Result;

public class ResultWarnTests
{
    public static TheoryData<Result, Action<Result, IResultMessage>> TestData => new()
    {
        { TestResult.Success, Assertions.ResultSuccessWithWarning },
        { TestResult.Failure, Assertions.ResultFailureWithoutWarnings }
    };
    
    [Theory, MemberData(nameof(TestData))]
    public void Warn_AddsWarningToResult(Result initial, Action<Result, IResultMessage> validate)
    {
        var result = initial.Warn(TestValues.Warning);
        
        validate(result, TestValues.Warning);
    }
}