using Funcer.Messages;

namespace Funcer.Tests;

public class ErrorTests
{
    private static class Errors
    {
        public static ErrorMessage SomethingExploded(DateTime time, string abc) => new(nameof(SomethingExploded), $"{abc} exploded at {time}");
    }

    [Fact]
    public void Test()
    {
        var error = Errors.SomethingExploded(DateTime.Now, "Code");

        error.MessageType.Should().Be(MessageType.Basic);
    }
}