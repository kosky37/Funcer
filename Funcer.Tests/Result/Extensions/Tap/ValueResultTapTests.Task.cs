using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Tap;

using Result = Funcer.Result;

public class ValueResultTapTests_Task
{
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Async.Success.V2, AsyncFunc.Returns.Success.Alpha1, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V2, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.Success.Alpha1, TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_Tap_ValueResultTask(Task<Result<Types.Alpha>> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Task<Result>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Returns.Success.Empty, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Returns.Failure.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.Success.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.Failure.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_Tap_ResultTask(Task<Result<Types.Alpha>> first, Func<Task<Result>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Func<Task<Result<Types.Beta>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Returns.Success.Beta1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Returns.Failure.Beta, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.Success.Beta1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.Failure.Beta, TestValues.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask1_Tap_ValueResult2Task(Task<Result<Types.Alpha>> first, Func<Task<Result<Types.Beta>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Task<Result<Types.Beta>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, TestValues.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResultTask1_Tap_ValueResult2Task_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task<Result<Types.Beta>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Task<Result>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData5 => new()
    {
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Takes.Alpha.Returns.Success.Empty, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Takes.Alpha.Returns.Failure.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Success.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Failure.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResultTask_Tap_ResultTask_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task<Result>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Task>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData6 => new()
    {
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Returns.Void, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.Void, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResultTask_Tap_Task(Task<Result<Types.Alpha>> first, Func<Task> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);
    
        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Task<Types.Beta>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData7 => new()
    {
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Returns.Beta1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Returns.Beta1, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResultTask1_Tap_Value2Task(Task<Result<Types.Alpha>> first, Func<Task<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Task>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Alpha.Async.Success.V1, AsyncFunc.Takes.Alpha.Returns.Nothing, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Nothing, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResultTask_Tap_Task_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
}