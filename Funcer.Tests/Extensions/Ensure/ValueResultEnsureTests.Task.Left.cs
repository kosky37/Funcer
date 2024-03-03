using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Ensure;

public class ValueResultEnsureTests_Task_Left
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, true, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, false, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, true, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, false, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_Ensure_Condition(Task<Result<Types.Alpha>> first, bool condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result, Values.Alpha1);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.True, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.False, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.True, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.False, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_Ensure_ConditionFunction(Task<Result<Types.Alpha>> first, Func<bool> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result, Values.Alpha1);
    }
    
    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.IsTrue, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha2, Functions.Takes.Alpha.Returns.IsFalse, Values.Alpha2, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.IsFalse, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Success.Alpha2, Functions.Takes.Alpha.Returns.IsTrue, Values.Alpha2, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.IsTrue, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.IsFalse, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask_Ensure_ConditionFunctionWithParameter(Task<Result<Types.Alpha>> first, Func<Types.Alpha, bool> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result, expectedValue);
    }
}