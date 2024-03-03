using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Ensure;

public class ResultEnsureTests_Task
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing, Tasks.Returns.True, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Nothing, Tasks.Returns.False, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Tasks.Returns.True, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Nothing, Tasks.Returns.False, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ResultTask_Ensure_ConditionTask(Task<Result> first, Func<Task<bool>> condition, Action<Result> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result);
    }
}