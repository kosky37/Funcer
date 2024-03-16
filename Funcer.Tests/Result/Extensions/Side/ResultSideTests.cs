using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Side;

using Result = Funcer.Result;

public class ResultSideTests
{
    public static TheoryData<Result, Func<Result>, Action<Result, IResultMessage>> TestData1 => new()
    {
        { TestResult.Success, TestFunc.Returns.Failure.Empty, Assertions.ResultSuccessWithWarning },
        { TestResult.Success, TestFunc.Returns.Success.Empty, Assertions.ResultSuccessWithoutWarnings },
        { TestResult.Failure, TestFunc.Returns.Failure.Empty, Assertions.ResultFailureWithoutWarnings },
        { TestResult.Failure, TestFunc.Returns.Success.Empty, Assertions.ResultFailureWithoutWarnings }
    };

    [Theory, MemberData(nameof(TestData1))]
    public void Result_Side_ResultFunc(Result first, Func<Result> next, Action<Result, IResultMessage> validate)
    {
        var result = first
            .Side(next);

        validate(result, TestValues.Error);
    }

    public static TheoryData<Result, Func<Result<Types.Alpha>>, Action<Result, IResultMessage>> TestData2 => new()
    {
        { TestResult.Success, TestFunc.Returns.Failure.Alpha, Assertions.ResultSuccessWithWarning },
        { TestResult.Success, TestFunc.Returns.Success.Alpha1, Assertions.ResultSuccessWithoutWarnings },
        { TestResult.Failure, TestFunc.Returns.Failure.Alpha, Assertions.ResultFailureWithoutWarnings },
        { TestResult.Failure, TestFunc.Returns.Success.Alpha1, Assertions.ResultFailureWithoutWarnings }
    };

    [Theory, MemberData(nameof(TestData2))]
    public void Result_Side_ValueResultFunc(Result first, Func<Result<Types.Alpha>> next,
        Action<Result, IResultMessage> validate)
    {
        var result = first
            .Side(next);

        validate(result, TestValues.Error);
    }
}