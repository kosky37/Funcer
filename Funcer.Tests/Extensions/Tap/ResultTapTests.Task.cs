using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Tap;

public class ResultTapTests_Task
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Tasks.Returns.Success.Empty, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Nothing, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Tasks.Returns.Success.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_Tap_ResultTask(Task<Result> first, Func<Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Tasks.Returns.Success.Alpha1, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Nothing, Tasks.Returns.Failure.Alpha, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Tasks.Returns.Success.Alpha1, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Tasks.Returns.Failure.Alpha, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ResultTask_Tap_ValueResultTask(Task<Result> first, Func<Task<Result<Types.Alpha>>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Tasks.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Failure.Nothing, Tasks.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ResultTask_Tap_Task(Task<Result> first, Func<Task> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData4 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Tasks.Returns.Alpha1, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Failure.Nothing, Tasks.Returns.Alpha1, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData4))]
    public async Task ResultTask_Tap_ValueTask(Task<Result> first, Func<Task<Types.Alpha>> next, Action<Result> validate)
    {
        var result = await first
            .Tap(next);

        validate(result);
    }
}