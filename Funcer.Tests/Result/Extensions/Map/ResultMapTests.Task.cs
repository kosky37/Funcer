using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Map;

using Result = Funcer.Result;

public class ResultMapTests_Task
{
    public static TheoryData<Task<Result>, Func<Task<Result>>, Action<Result>> TaskTestData1 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Async.Success, AsyncFunc.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TaskTestData1))]
    public async Task Should_Return_Result_When_Map_On_Result_Task_With_Result_Task(Task<Result> first, Func<Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData2 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, AsyncFunc.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Async.Failure, AsyncFunc.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TaskTestData2))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_Task_With_ValueResult_Task(Task<Result> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result>, Func<Task>, Action<Result>> TaskTestData3 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.Void, Assertions.ResultSuccess },
        { TestResult.Async.Failure, AsyncFunc.Returns.Void, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TaskTestData3))]
    public async Task Should_Return_Result_When_Map_On_Result_Task_With_Action_Task(Task<Result> first, Func<Task> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData4 => new()
    {
        { TestResult.Async.Success, AsyncFunc.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Failure, AsyncFunc.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TaskTestData4))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_Task_With_Function_Task(Task<Result> first, Func<Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}