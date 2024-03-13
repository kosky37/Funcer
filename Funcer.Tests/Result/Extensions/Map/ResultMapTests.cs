using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Map;

using Result = Funcer.Result;

public class ResultMapTests
{
    public static TheoryData<Result, Func<Result>, Action<Result>> TestData1 => new()
    {
        { TestResult.Success, TestFunc.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Success, TestFunc.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Failure, TestFunc.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Failure, TestFunc.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Return_Result_When_Map_On_Result_With_Result(Result first, Func<Result> next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Result, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Success, TestFunc.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, TestFunc.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, TestFunc.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public void Should_Return_ValueResult_When_Map_On_Result_With_ValueResult(Result first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);
            
        validate(result, expectedValue);
    }
    
    public static TheoryData<Result, Action, Action<Result>> TestData3 => new()
    {
        { TestResult.Success, TestFunc.Returns.Void, Assertions.ResultSuccess },
        { TestResult.Failure, TestFunc.Returns.Void, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData3))]
    public void Should_Return_Result_When_Map_On_Result_With_Action(Result first, Action next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Result, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Success, TestFunc.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Failure, TestFunc.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData4))]
    public void Should_Return_ValueResult_When_Map_On_Result_With_Function(Result first, Func<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
}