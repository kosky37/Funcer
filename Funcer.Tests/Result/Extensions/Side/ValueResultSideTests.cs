using Funcer.Messages;
using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Side;

using Result = Funcer.Result;

public class ValueResultSideTests
{
    public static TheoryData<Result<Types.Alpha>, Func<Result>, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage>> TestData1 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Returns.Failure.Empty, Assertions.ValueResultSuccessWithWarning },
        { TestResult.Alpha.Success.V1, TestFunc.Returns.Success.Empty, Assertions.ValueResultSuccessWithoutWarnings },
        { TestResult.Alpha.Failure, TestFunc.Returns.Failure.Empty, Assertions.ValueResultFailureWithoutWarnings },
        { TestResult.Alpha.Failure, TestFunc.Returns.Success.Empty, Assertions.ValueResultFailureWithoutWarnings }
    };

    [Theory, MemberData(nameof(TestData1))]
    public void Result_Side_ResultFunc(Result<Types.Alpha> first, Func<Result> next, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage> validate)
    {
        var result = first
            .Side(next);

        validate(result, TestValues.Alpha1, TestValues.Error);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Result<Types.Alpha>>, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage>> TestData2 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Returns.Failure.Alpha, Assertions.ValueResultSuccessWithWarning },
        { TestResult.Alpha.Success.V1, TestFunc.Returns.Success.Alpha1, Assertions.ValueResultSuccessWithoutWarnings },
        { TestResult.Alpha.Failure, TestFunc.Returns.Failure.Alpha, Assertions.ValueResultFailureWithoutWarnings },
        { TestResult.Alpha.Failure, TestFunc.Returns.Success.Alpha1, Assertions.ValueResultFailureWithoutWarnings }
    };

    [Theory, MemberData(nameof(TestData2))]
    public void Result_Side_ValueResultFunc(Result<Types.Alpha> first, Func<Result<Types.Alpha>> next, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage> validate)
    {
        var result = first
            .Side(next);

        validate(result, TestValues.Alpha1, TestValues.Error);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Result<Types.Beta>>, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage>> TestData3 => new()
    {
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.Failure.Beta, Assertions.ValueResultSuccessWithWarning },
        { TestResult.Alpha.Success.V1, TestFunc.Takes.Alpha.Returns.Success.Beta1, Assertions.ValueResultSuccessWithoutWarnings },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.Failure.Beta, Assertions.ValueResultFailureWithoutWarnings },
        { TestResult.Alpha.Failure, TestFunc.Takes.Alpha.Returns.Success.Beta1, Assertions.ValueResultFailureWithoutWarnings }
    };
    
    [Theory, MemberData(nameof(TestData3))]
    public void Result_Side_ValueResultFunc_Param(Result<Types.Alpha> first, Func<Types.Alpha, Result<Types.Beta>> next, Action<Result<Types.Alpha>, Types.Alpha, IResultMessage> validate)
    {
        var result = first
            .Side(next);

        validate(result, TestValues.Alpha1, TestValues.Error);
    }
}