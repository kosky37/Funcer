using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Tap;

public class ResultTapTests
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Functions.Returns.Success.Empty, Assertions.ResultSuccess },
            new object[] { Results.Success.Nothing, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.Success.Empty, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public void Result_Tap_FuncResult(Result first, Func<Result> next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Functions.Returns.Success.Alpha1, Assertions.ResultSuccess },
            new object[] { Results.Success.Nothing, Functions.Returns.Failure.Alpha, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.Success.Alpha1, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, Functions.Returns.Failure.Alpha, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public void Result_Tap_FuncValueResult(Result first, Func<Result<Types.Alpha>> next, Action<Result> validate)
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
    public void Result_Tap_Action(Result first, Action next, Action<Result> validate)
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
    public void Result_Tap_FuncAlpha(Result first, Func<Types.Alpha> next, Action<Result> validate)
    {
        var result = first
            .Tap(next);

        validate(result);
    }
}