using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Map;

using Result = Funcer.Result;

public class ValueResultMapTests
{
    public static TheoryData<Result<Types.Alpha>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Success.V1, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult
        (Result<Types.Alpha> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Result>, Action<Result>> TestData2 => new()
    {
        { TestResult.Alpha.Success.V1, Functions.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Alpha.Success.V1, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, Functions.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public void Should_Return_Result_When_Map_On_ValueResult_With_Result
        (Result<Types.Alpha> first, Func<Result> next, Action<Result> validate)
    {
        var result = first
            .Map(_ => next());

        validate(result);
    }

    public static TheoryData<Result<Types.Beta>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Beta.Success.V1, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData3))]
    public void Should_Return_ValueResult_When_Map_On_ValueResult_With_Different_ValueResult
        (Result<Types.Beta> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(_ => next());

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Beta>, Func<Types.Beta, Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Beta.Success.V1, Functions.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, Functions.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, Functions.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, Functions.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData4))]
    public void Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult
        (Result<Types.Beta> first, Func<Types.Beta, Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Result>, Action<Result>> TestData5 => new()
    {
        { TestResult.Alpha.Success.V1, Functions.Takes.Alpha.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Alpha.Success.V1, Functions.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, Functions.Takes.Alpha.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Failure, Functions.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData5))]
    public void Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_With_Result
        (Result<Types.Alpha> first, Func<Types.Alpha, Result> next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Result<Types.Alpha>, Action, Action<Result>> TestData6 => new()
    {
        { TestResult.Alpha.Success.V1, Functions.Returns.Nothing, Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, Functions.Returns.Nothing, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public void Should_Return_Result_When_Map_On_ValueResult_With_Action
        (Result<Types.Alpha> first, Action next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Result<Types.Alpha>, Action<Types.Alpha>, Action<Result>> TestData7 => new()
    {
        { TestResult.Alpha.Success.V1, Functions.Takes.Alpha.Returns.Nothing, Assertions.ResultSuccess },
        { TestResult.Alpha.Failure, Functions.Takes.Alpha.Returns.Nothing, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public void Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_With_Action
        (Result<Types.Alpha> first, Action<Types.Alpha> next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Result<Types.Beta>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Beta.Success.V1, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public void Should_Return_ValueResult_When_Map_On_ValueResult_With_Function
        (Result<Types.Beta> first, Func<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Beta>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData9 => new()
    {
        { TestResult.Beta.Success.V1, Functions.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, Functions.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData9))]
    public void Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_With_Function
        (Result<Types.Beta> first, Func<Types.Beta, Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
}