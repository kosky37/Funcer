using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Warn;

public class ValueResultWarnTests
{
    public static TheoryData<Result<Types.Alpha>, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage>> TestData => new()
    {
        { TestResult.Alpha.Success.V1, Assertions.ValueResultSuccessWithWarning },
        { TestResult.Alpha.Failure, Assertions.ValueResultFailureWithoutWarnings }
    };
    
    [Theory, MemberData(nameof(TestData))]
    public void Warn_AddsWarningToValueResult(Result<Types.Alpha> initial, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage> validate)
    {
        var result = initial.Warn(TestValues.Warning);
        
        validate(result, TestValues.Alpha1, TestValues.Warning);
    }
}