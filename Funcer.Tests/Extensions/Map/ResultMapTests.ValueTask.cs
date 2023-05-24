using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Map;

public partial class ResultMapTests
{
    public static IEnumerable<object[]> ValueTaskTestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, FunctionsOld.Success.WithValueTask.Void, Assertions.ResultSuccess },
            new object[] { Results.Success.Nothing, FunctionsOld.Failure.WithValueTask.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Success.WithValueTask.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Failure.WithValueTask.Void, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(ValueTaskTestData1))]
    public async ValueTask Should_Return_Result_When_Map_On_Result_With_Result_ValueTask(Result first, Func<ValueTask<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, FunctionsOld.Success.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Nothing, FunctionsOld.Failure.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Success.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Nothing, FunctionsOld.Failure.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(ValueTaskTestData2))]
    public async ValueTask Should_Return_ValueResult_When_Map_On_Result_With_ValueResult_ValueTask(Result first, Func<ValueTask<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData3 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, ValueTasks.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Nothing, ValueTasks.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(ValueTaskTestData3))]
    public async ValueTask Should_Return_Result_When_Map_On_Result_With_Action_ValueTask(Result first, Func<ValueTask> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData4 => 
        new List<object[]>
        {
            new object[] { Results.Success.Nothing, ValueTasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Nothing, ValueTasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(ValueTaskTestData4))]
    public async ValueTask Should_Return_ValueResult_When_Map_On_Result_With_Function_ValueTask(Result first, Func<ValueTask<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}