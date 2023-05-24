using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Tap;

public partial class ResultTapTests
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, FunctionsOld.Success.WithDefault.Void, Assertions.ResultSuccess },
            new object[] { Results.Success.Nothing, FunctionsOld.Failure.WithDefault.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Success.WithDefault.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Failure.WithDefault.Void, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Return_Result_When_Tap_On_Result_With_Result(Result first, Func<Result> next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, FunctionsOld.Success.WithDefault.Alpha, Assertions.ResultSuccess },
            new object[] { Results.Success.Nothing, FunctionsOld.Failure.WithDefault.Alpha, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Success.WithDefault.Alpha, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Failure.WithDefault.Alpha, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public void Should_Return_Result_When_Tap_On_Result_With_ValueResult(Result first, Func<Result<Types.Alpha>> next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Functions.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Nothing, Functions.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData3))]
    public void Should_Return_Result_When_Tap_On_Result_With_Action(Result first, Action next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData4 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Functions.Returns.Alpha1, Assertions.ResultSuccess },
            new object[] { Results.Failure.Nothing, Functions.Returns.Alpha1, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData4))]
    public void Should_Return_Result_When_Tap_On_Result_With_Function(Result first, Func<Types.Alpha> next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
}