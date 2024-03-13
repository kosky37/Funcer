using Funcer.Tests.Common;
using Xunit.Abstractions;

namespace Funcer.Tests;

public class ResultTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Should_Return_Success()
    {
        var result = Funcer.Result.Create(true, Values.TestError)
            .Map(() => "one")
            .Tap(x => testOutputHelper.WriteLine(x.TrimEnd('e') + "ce"))
            .Tap(testOutputHelper.WriteLine)
            .Tap(_ => testOutputHelper.WriteLine("abc"))
            .Map(x => 7)
            .Map(x => { testOutputHelper.WriteLine(x.ToString()); })
            .Tap(() => { })
            .Map(() => "abc")
            .Ensure(Functions.Returns.True, Values.TestError)
            .Map(x => x + "def")
            .Ensure(x => x is "abcdef", Values.TestError)
            .Tap(() => "abc")
            .Roll(Funcer.Result.Success("ghi"))
            .Side(() => Funcer.Result.Failure(Values.TestError))
            .Map((first, second) => first + second);
            
    
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("abcdefghi");
        result.Warnings.Should().Contain(x => x.Type == Values.TestError.Type);
    }
}