using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Ensure;

public partial class ValueResultEnsureTests
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, true, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, false, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, true, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, false, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Return_Correct_Result_With_Condition(Result<Types.Alpha> first, bool condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, Values.TestError);

        validate(result, Values.Alpha1);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.True.WithDefault, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.False.WithDefault, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.True.WithDefault, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.False.WithDefault, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData2))]
    public void Should_Return_Correct_Result_With_Condition_Function(Result<Types.Alpha> first, Func<bool> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, Values.TestError);

        validate(result, Values.Alpha1);
    }
    
    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Bool.IsTrue, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha2, FunctionsOld.Bool.IsFalse, Values.Alpha2, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Bool.IsFalse, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Success.Alpha2, FunctionsOld.Bool.IsTrue, Values.Alpha2, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Bool.IsTrue, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Bool.IsFalse, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData3))]
    public void Should_Return_Correct_Result_With_Condition_Based_On_Value(Result<Types.Alpha> first, Func<Types.Alpha, bool> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = first
            .Ensure(condition, Values.TestError);

        validate(result, expectedValue);
    }
}