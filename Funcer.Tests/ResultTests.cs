using FluentAssertions;
using Funcer.Tests.Common;
using Xunit.Abstractions;

namespace Funcer.Tests;

public partial class ResultTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ResultTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Should_Return_Success()
    {
        var result = Result.Create(true, Values.TestError)
            .Map(() => "one")
            .Tap(x => _testOutputHelper.WriteLine(x))
            .Tap(_testOutputHelper.WriteLine)
            .Tap(_ => _testOutputHelper.WriteLine("abc"))
            .Map(x => 7)
            .Map(x => { _testOutputHelper.WriteLine(x.ToString()); })
            .Tap(() => { })
            .Map(() => "abc")
            .Ensure(FunctionsOld.True.WithDefault, Values.TestError)
            .Map(x => x + "def")
            .Ensure(x => x is "abcdef", Values.TestError)
            .Tap(() => "abc")
            .Roll(Result.Success("ghi"))
            .Map(x => x.Item1 + x.Item2);
            

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("abcdefghi");
    }
}