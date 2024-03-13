using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Map;

using Result = Funcer.Result;

public class ResultMapTests_Task_Left
{
    public static TheoryData<Task<Result>, Func<Result>, Action<Result>> TaskTestData1 => new()
    {
        { TestResult.Async.Success, Functions.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Async.Success, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, Functions.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Async.Failure, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TaskTestData1))]
    public async Task Should_Return_Result_When_Map_On_Result_Task_With_Result(Task<Result> first, Func<Result> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData2 => new()
    {
        { TestResult.Async.Success, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Success, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Async.Failure, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Async.Failure, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TaskTestData2))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_Task_With_ValueResult(Task<Result> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result>, Action, Action<Result>> TaskTestData3 => new()
    {
        { TestResult.Async.Success, Functions.Returns.Nothing, Assertions.ResultSuccess },
        { TestResult.Async.Failure, Functions.Returns.Nothing, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TaskTestData3))]
    public async Task Should_Return_Result_When_Map_On_Result_Task_With_Action(Task<Result> first, Action next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Task<Result>, Func<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData4 => new()
    {
        { TestResult.Async.Success, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Async.Failure, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TaskTestData4))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_Task_With_Function(Task<Result> first, Func<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}