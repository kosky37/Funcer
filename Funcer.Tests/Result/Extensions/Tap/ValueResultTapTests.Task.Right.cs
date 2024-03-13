using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Tap;

using Result = Funcer.Result;

public class ValueResultTapTests_Task_Right
{
    public static TheoryData<Result<Types.Alpha>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Success.V2, Tasks.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V2, Tasks.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResult_Tap_ValueResultTask(Result<Types.Alpha> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Task<Result>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Success.V1, Tasks.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, Tasks.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResult_Tap_ResultTask(Result<Types.Alpha> first, Func<Task<Result>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }

    public static TheoryData<Result<Types.Alpha>, Func<Task<Result<Types.Beta>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Success.V1, Tasks.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, Tasks.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResult1_Tap_ValueResult2Task(Result<Types.Alpha> first, Func<Task<Result<Types.Beta>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Task<Result<Types.Beta>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Success.V1, Tasks.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, Tasks.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResult1_Tap_ValueResult2Task_Param(Result<Types.Alpha> first, Func<Types.Alpha, Task<Result<Types.Beta>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Task<Result>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData5 => new()
    {
        { TestResult.Alpha.Success.V1, Tasks.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, Tasks.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, Tasks.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResult_Tap_ResultTask_Param(Result<Types.Alpha> first, Func<Types.Alpha, Task<Result>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Task>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData6 => new()
    {
        { TestResult.Alpha.Success.V1, Tasks.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, Tasks.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResult_Tap_Task(Result<Types.Alpha> first, Func<Task> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);
    
        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Task<Types.Beta>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData7 => new()
    {
        { TestResult.Alpha.Success.V1, Tasks.Returns.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, Tasks.Returns.Beta1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResult1_Tap_Value2Task(Result<Types.Alpha> first, Func<Task<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Alpha>, Func<Types.Alpha, Task>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Alpha.Success.V1, Tasks.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Failure, Tasks.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResult_Tap_Task_Param(Result<Types.Alpha> first, Func<Types.Alpha, Task> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
}