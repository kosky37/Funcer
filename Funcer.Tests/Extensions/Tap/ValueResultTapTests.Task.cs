using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Tap;

public class ValueResultTapTests_Task
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha2, Tasks.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha2, Tasks.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_Tap_ValueResultTask(Task<Result<Types.Alpha>> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_Tap_ResultTask(Task<Result<Types.Alpha>> first, Func<Task<Result>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }

    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask1_Tap_ValueResult2Task(Task<Result<Types.Alpha>> first, Func<Task<Result<Types.Beta>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData4 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResultTask1_Tap_ValueResult2Task_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task<Result<Types.Beta>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData5 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResultTask_Tap_ResultTask_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task<Result>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData6 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResultTask_Tap_Task(Task<Result<Types.Alpha>> first, Func<Task> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);
    
        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData7 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Beta1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResultTask1_Tap_Value2Task(Task<Result<Types.Alpha>> first, Func<Task<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData8 =>
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResultTask_Tap_Task_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
}