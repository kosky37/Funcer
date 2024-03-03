using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Tap;

public class ValueResultTapTests_Task_Left
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha2, Functions.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha2, Functions.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_Tap_ValueResultFunction(Task<Result<Types.Alpha>> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_Tap_ResultFunction(Task<Result<Types.Alpha>> first, Func<Result> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }

    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask1_Tap_ValueResult2Function(Task<Result<Types.Alpha>> first, Func<Result<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData4 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResultTask1_Tap_ValueResult2Function_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData5 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResultTask_Tap_ResultFunction_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData6 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResultTask_Tap_Action(Task<Result<Types.Alpha>> first, Action next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);
    
        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData7 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Beta1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResultTask1_Tap_Value2Function(Task<Result<Types.Alpha>> first, Func<Types.Beta> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData8 =>
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResultTask_Tap_Action_Param(Task<Result<Types.Alpha>> first, Action<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
}