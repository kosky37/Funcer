using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Tap;

using Result = Funcer.Result;

public class ValueResultTapTests_Task_Left
{
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Async.Success.V2, Functions.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V2, Functions.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Returns.Success.Alpha1, Values.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Returns.Failure.Alpha, Values.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_Tap_ValueResultFunction(Task<Result<Types.Alpha>> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Functions.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, Functions.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_Tap_ResultFunction(Task<Result<Types.Alpha>> first, Func<Result> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result<Types.Beta>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Functions.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, Functions.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask1_Tap_ValueResult2Function(Task<Result<Types.Alpha>> first, Func<Result<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Result<Types.Beta>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Functions.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, Functions.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Takes.Alpha.Returns.Success.Beta1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Takes.Alpha.Returns.Failure.Beta, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResultTask1_Tap_ValueResult2Function_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Result>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData5 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Functions.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, Functions.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Takes.Alpha.Returns.Success.Empty, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Functions.Takes.Alpha.Returns.Failure.Empty, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResultTask_Tap_ResultFunction_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Action, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData6 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Functions.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, Functions.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResultTask_Tap_Action(Task<Result<Types.Alpha>> first, Action next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);
    
        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Beta>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData7 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Functions.Returns.Beta1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, Functions.Returns.Beta1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResultTask1_Tap_Value2Function(Task<Result<Types.Alpha>> first, Func<Types.Beta> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Action<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Functions.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, Functions.Takes.Alpha.Returns.Nothing, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResultTask_Tap_Action_Param(Task<Result<Types.Alpha>> first, Action<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
}