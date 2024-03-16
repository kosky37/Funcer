using Funcer.Tests.Common;
using Xunit.Abstractions;

namespace Funcer.Tests;

public class ResultTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Should_Return_Success()
    {
        var result = Funcer.Result.Create(true, TestValues.Error)
            .Map(() => "one")
            .Tap(x => testOutputHelper.WriteLine(x.TrimEnd('e') + "ce"))
            .Tap(testOutputHelper.WriteLine)
            .Tap(_ => testOutputHelper.WriteLine("abc"))
            .Map(_ => 7)
            .Tap(x => { testOutputHelper.WriteLine(x.ToString()); })
            .Tap(() => { })
            .Map(() => "abc")
            .Ensure(TestFunc.Returns.True, TestValues.Error)
            .Map(x => x + "def")
            .Ensure(x => x is "abcdef", TestValues.Error)
            .Tap(() => "abc")
            .Roll(Funcer.Result.Success("ghi"))
            .Side(() => Funcer.Result.Failure(TestValues.Error))
            .Map((first, second) => first + second);
            
    
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("abcdefghi");
        result.Warnings.Should().Contain(x => x.Type == TestValues.Error.Type);
    }
}