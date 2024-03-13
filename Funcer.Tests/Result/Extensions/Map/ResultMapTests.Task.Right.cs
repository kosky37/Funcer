using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Map;

using Result = Funcer.Result;

public class ResultMapTests_Task_Right
{
    public static TheoryData<Result, Func<Task<Result>>, Action<Result>> TaskTestData1 => new()
    {
        { TestResult.Success, Tasks.Returns.Success.Empty, Assertions.ResultSuccess },
        { TestResult.Success, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
        { TestResult.Failure, Tasks.Returns.Success.Empty, Assertions.ResultFailure },
        { TestResult.Failure, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
    };

    [Theory, MemberData(nameof(TaskTestData1))]
    public async Task Should_Return_Result_When_Map_On_Result_With_Result_Task(Result first, Func<Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Result, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData2 => new()
    {
        { TestResult.Success, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Success, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Failure, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TaskTestData2))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_With_ValueResult_Task(Result first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result, Func<Task>, Action<Result>> TaskTestData3 => new()
    {
        { TestResult.Success, Tasks.Returns.Nothing, Assertions.ResultSuccess },
        { TestResult.Failure, Tasks.Returns.Nothing, Assertions.ResultFailure }
    };

    [Theory, MemberData(nameof(TaskTestData3))]
    public async Task Should_Return_Result_When_Map_On_Result_With_Action_Task(Result first, Func<Task> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static TheoryData<Result, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData4 => new()
    {
        { TestResult.Success, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Failure, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TaskTestData4))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_With_Function_Task(Result first, Func<Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}