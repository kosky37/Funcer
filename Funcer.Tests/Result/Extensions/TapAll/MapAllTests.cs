using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.TapAll;

public class TapAllTests
{
    [Fact]
    public async Task SanityCheck()
    {
        var tasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1, TestResult.Alpha.Async.Success.V2
        };
        
        var result = await tasks.TapAll(x => 7);

        result.Value.First().Value.Should().BeTrue();
        result.Value.Last().Value.Should().BeFalse();
    }
}