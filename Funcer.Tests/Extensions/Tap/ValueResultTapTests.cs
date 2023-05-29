using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Tap;

public class ValueResultTapTests
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha2, Functions.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha2, Functions.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Return_First_ValueResult_When_Tap_On_ValueResult_With_ValueResult(Result<Types.Alpha> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Functions.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, Functions.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public void Should_Return_ValueResult_When_Tap_On_ValueResult_With_Result(Result<Types.Alpha> first, Func<Result> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Tap(_ => next());

        validate(result, expectedValue);
    }

    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Functions.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, Functions.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData3))]
    public void Should_Return_First_ValueResult_When_Tap_On_ValueResult_With_Different_ValueResult(Result<Types.Alpha> first, Func<Result<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Tap(_ => next());

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData4 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Functions.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, Functions.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData4))]
    public void Should_Pass_A_Param_And_Return_First_ValueResult_When_Tap_On_ValueResult_With_Different_ValueResult(Result<Types.Alpha> first, Func<Types.Alpha, Result<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData5 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Functions.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, Functions.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Functions.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData5))]
    public void Should_Pass_A_Param_And_Return_ValueResult_When_Tap_On_ValueResult_With_Result(Result<Types.Alpha> first, Func<Types.Alpha, Result> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData6 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Functions.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Alpha, Functions.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData6))]
    public void Should_Return_ValueResult_When_Tap_On_ValueResult_With_Action(Result<Types.Alpha> first, Action next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Tap(next);
    
        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData7 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Functions.Returns.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Alpha, Functions.Returns.Beta1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData7))]
    public void Should_Return_ValueResult_When_Tap_On_ValueResult_With_Function(Result<Types.Alpha> first, Func<Types.Beta> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData8 =>
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Functions.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Alpha, Functions.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData8))]
    public void Should_Pass_A_Param_And_Return_ValueResult_When_Tap_On_ValueResult_With_Action(Result<Types.Alpha> first, Action<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Tap(next);

        validate(result, expectedValue);
    }
}