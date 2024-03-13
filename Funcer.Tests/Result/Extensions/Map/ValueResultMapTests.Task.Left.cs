using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Map;

using Result = Funcer.Result;

public class ValueResultMapTests_Task_Left
{
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_ValueResult_Function
        (Task<Result<Types.Alpha>> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result>, Action<Result>> TestData2 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_Task_With_Result_Function
        (Task<Result<Types.Alpha>> first, Func<Result> next, Action<Result> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result);
    }

    public static TheoryData<Task<Result<Types.Beta>>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Beta.Async.Success.V1, TestFunc.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, TestFunc.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, TestFunc.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, TestFunc.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_Different_ValueResult_Function
        (Task<Result<Types.Beta>> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Beta>>, Func<Types.Beta, Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Beta.Async.Success.V1, TestFunc.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, TestFunc.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, TestFunc.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, TestFunc.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_Task_With_ValueResult_Parameterized_Function
        (Task<Result<Types.Beta>> first, Func<Types.Beta, Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Result>, Action<Result>> TestData5 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_Task_With_Parameterized_Result_Function
        (Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Action, Action<Result>> TestData6 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Void, Assertions.ResultSuccess },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Void, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_Task_With_Action
        (Task<Result<Types.Alpha>> first, Action next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Action<Types.Alpha>, Action<Result>> TestData7 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.Nothing, Assertions.ResultSuccess },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.Nothing, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_Task_With_Parameterized_Action
        (Task<Result<Types.Alpha>> first, Action<Types.Alpha> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result<Types.Beta>>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Beta.Async.Success.V1, TestFunc.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, TestFunc.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_Function
        (Task<Result<Types.Beta>> first, Func<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Beta>>, Func<Types.Beta, Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData9 => new()
    {
        { TestResult.Beta.Async.Success.V1, TestFunc.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, TestFunc.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData9))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_Task_With_Parameterized_Function
        (Task<Result<Types.Beta>> first, Func<Types.Beta, Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}