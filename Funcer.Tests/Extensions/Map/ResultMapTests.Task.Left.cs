using Funcer.Generator.Attributes;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Map;

[ValueTaskVariantGenerator]
public class ResultMapTests_Task_Left
{
    public static IEnumerable<object[]> TaskTestData1 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Functions.Returns.Success.Empty, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Nothing, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Functions.Returns.Success.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TaskTestData1))]
    public async Task Should_Return_Result_When_Map_On_Result_Task_With_Result(Task<Result> first, Func<Result> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TaskTestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Nothing, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TaskTestData2))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_Task_With_ValueResult(Task<Result> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TaskTestData3 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Functions.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Failure.Nothing, Functions.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TaskTestData3))]
    public async Task Should_Return_Result_When_Map_On_Result_Task_With_Action(Task<Result> first, Action next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TaskTestData4 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Nothing, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TaskTestData4))]
    public async Task Should_Return_ValueResult_When_Map_On_Result_Task_With_Function(Task<Result> first, Func<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}