using Funcer.Messages;
using Funcer.Tests.Common;
using Xunit.Abstractions;

namespace Funcer.Tests.General;

using Result = Funcer.Result;

public class ResultTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Should_Return_Success()
    {
        var result = Result.Create(true, TestValues.Error)
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
            .Roll(Result.Success("ghi"))
            .Side(() => Result.Failure(TestValues.Error))
            .Map((first, second) => first + second);
            
        
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("abcdefghi");
        result.Warnings.Should().Contain(x => x.Type == TestValues.Error.Type);
    }
}