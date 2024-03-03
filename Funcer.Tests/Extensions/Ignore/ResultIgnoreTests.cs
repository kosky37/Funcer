using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Ignore;

public class ResultIgnoreTests
{
    public static IEnumerable<object[]> TestData1 => 
    new List<object[]>
    {
        new object[] { Results.Success.Nothing },
        new object[] { Results.Failure.Nothing }
    };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Ignore_Result(Result result)
    {
        result.Ignore();
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Nothing },
            new object[] { Results.Tasks.Failure.Nothing }
        };
    
    [Theory, MemberData(nameof(TestData2))]
    public async Task Should_Ignore_Result_Task(Task<Result> resultTask)
    {
        await resultTask.Ignore();
    }
}