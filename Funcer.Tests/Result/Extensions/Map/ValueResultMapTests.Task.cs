using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Map;

using Result = Funcer.Result;

public class ValueResultMapTests_Task
{
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_ValueResult_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Task<Result>>, Action<Result>> TestData2 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Tasks.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Alpha.Async.Success.V1, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Async.Failure, Tasks.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Async.Failure, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_Task_With_Result_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result);
    }

    public static TheoryData<Task<Result<Types.Beta>>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Beta.Async.Success.V1, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_Different_ValueResult_Function_Task
        (Task<Result<Types.Beta>> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Beta>>, Func<Types.Beta, Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Beta.Async.Success.V1, Tasks.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Success.V1, Tasks.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, Tasks.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Async.Failure, Tasks.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_Task_With_ValueResult_Parameterized_Function_Task
        (Task<Result<Types.Beta>> first, Func<Types.Beta, Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Task<Result>>, Action<Result>> TestData5 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Tasks.Takes.Alpha.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Alpha.Async.Success.V1, Tasks.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Async.Failure, Tasks.Takes.Alpha.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Alpha.Async.Failure, Tasks.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_Task_With_Result_Parameterized_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Task>, Action<Result>> TestData6 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Tasks.Returns.Nothing, Assertions.ResultSuccess },
        { TestResult.Alpha.Async.Failure, Tasks.Returns.Nothing, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_Task_With_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Task> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Task>, Action<Result>> TestData7 => new()
    {
        { TestResult.Alpha.Async.Success.V1, Tasks.Takes.Alpha.Returns.Nothing, Assertions.ResultSuccess },
        { TestResult.Alpha.Async.Failure, Tasks.Takes.Alpha.Returns.Nothing, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_Task_With_Parameterized_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result<Types.Beta>>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Beta.Async.Success.V1, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_Function_Task
        (Task<Result<Types.Beta>> first, Func<Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Beta>>, Func<Types.Beta, Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData9 => new()
    {
        { TestResult.Beta.Async.Success.V1, Tasks.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Async.Failure, Tasks.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData9))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_Task_With_Parameterized_Function_Task
        (Task<Result<Types.Beta>> first, Func<Types.Beta, Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}