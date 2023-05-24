using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Map;

public partial class ValueResultMapTests
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Success.WithDefault.Alpha, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Failure.WithDefault.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Success.WithDefault.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Failure.WithDefault.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult
        (Result<Types.Alpha> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Success.WithDefault.Void, Assertions.ResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Failure.WithDefault.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Success.WithDefault.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Failure.WithDefault.Void, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public void Should_Return_Result_When_Map_On_ValueResult_With_Result
        (Result<Types.Alpha> first, Func<Result> next, Action<Result> validate)
    {
        var result = first
            .Map(_ => next());

        validate(result);
    }

    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, FunctionsOld.Success.WithDefault.Alpha, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Beta1, FunctionsOld.Failure.WithDefault.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Success.WithDefault.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Failure.WithDefault.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData3))]
    public void Should_Return_ValueResult_When_Map_On_ValueResult_With_Different_ValueResult
        (Result<Types.Beta> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(_ => next());

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData4 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, FunctionsOld.Success.WithDefault.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Beta1, FunctionsOld.Failure.WithDefault.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Success.WithDefault.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Failure.WithDefault.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData4))]
    public void Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult
        (Result<Types.Beta> first, Func<Types.Beta, Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData5 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Success.WithDefault.VoidWithAlphaParam, Assertions.ResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Failure.WithDefault.VoidWithAlphaParam, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Success.WithDefault.VoidWithAlphaParam, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Failure.WithDefault.VoidWithAlphaParam, Assertions.ResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData5))]
    public void Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_With_Result
        (Result<Types.Alpha> first, Func<Types.Alpha, Result> next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData6 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Functions.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Alpha, Functions.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData6))]
    public void Should_Return_Result_When_Map_On_ValueResult_With_Action
        (Result<Types.Alpha> first, Action next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData7 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Functions.Takes.Alpha.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Alpha, Functions.Takes.Alpha.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData7))]
    public void Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_With_Action
        (Result<Types.Alpha> first, Action<Types.Alpha> next, Action<Result> validate)
    {
        var result = first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData8 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Beta, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData8))]
    public void Should_Return_ValueResult_When_Map_On_ValueResult_With_Function
        (Result<Types.Beta> first, Func<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData9 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, Functions.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Beta, Functions.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
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