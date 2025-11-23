using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.MapAll;

public class MapAllTests
{
    [Fact]
    public async Task SanityCheck()
    {
        var tasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1, TestResult.Alpha.Async.Success.V2
        };
        
        var result = await tasks.MapAll(x => x.Value);

        result.Value.First().Should().BeTrue();
        result.Value.Last().Should().BeFalse();
    }
}