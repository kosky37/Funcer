using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Ignore;

public class ValueResultIgnoreTests
{
    public static IEnumerable<object[]> TestData1 => 
    new List<object[]>
    {
        new object[] { Results.Success.Alpha1 },
        new object[] { Results.Failure.Alpha }
    };

    [Theory, MemberData(nameof(TestData1))]
    public void Should_Ignore_Result(Result<Types.Alpha> result)
    {
        result.Ignore();
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1 },
            new object[] { Results.Tasks.Failure.Alpha }
        };
    
    [Theory, MemberData(nameof(TestData2))]
    public async Task Should_Ignore_Result_Task(Task<Result<Types.Alpha>> resultTask)
    {
        await resultTask.Ignore();
    }
}