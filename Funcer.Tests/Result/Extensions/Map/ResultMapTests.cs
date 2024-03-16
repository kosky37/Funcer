using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Map;

using Result = Funcer.Result;

public class ResultMapTests
{
    public static TheoryData<Result, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Success, TestFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public void Should_Return_ValueResult_When_Map_On_Result_With_ValueResult(Result first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);
            
        validate(result, expectedValue);
    }
    
    public static TheoryData<Result, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Success, TestFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Failure, TestFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public void Should_Return_ValueResult_When_Map_On_Result_With_Function(Result first, Func<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
}