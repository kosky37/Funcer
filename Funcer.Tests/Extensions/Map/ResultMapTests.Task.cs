using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Map;

public partial class ResultMapTests
{
    public static IEnumerable<object[]> TaskTestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, FunctionsOld.Success.WithTask.Void, Assertions.ResultSuccess },
            new object[] { Results.Success.Nothing, FunctionsOld.Failure.WithTask.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Success.WithTask.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Failure.WithTask.Void, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TaskTestData1))]
    public async Task Should_Return_Result_When_Map_On_Result_With_Result_Task(Result first, Func<Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TaskTestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, FunctionsOld.Success.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Nothing, FunctionsOld.Failure.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Success.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Failure.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TaskTestData2))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_With_ValueResult_Task(Result first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TaskTestData3 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Tasks.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Nothing, Tasks.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TaskTestData3))]
    public async ValueTask Should_Return_Result_When_Map_On_Result_With_Action_Task(Result first, Func<Task> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TaskTestData4 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Nothing, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TaskTestData4))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_With_Function_Task(Result first, Func<Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}