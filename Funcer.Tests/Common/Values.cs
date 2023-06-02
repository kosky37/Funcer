using Funcer.Messages;

namespace Funcer.Tests.Common;

public static class Values
{
    public static Error TestError => new(nameof(TestError), "Test message");
    public static Types.Alpha Alpha1 => new(true);
    public static Types.Alpha Alpha2 => new(false);
    public static Types.Beta Beta1 => new(1);
    public static Types.Beta Beta2 => new(2);
    public static Types.Beta Beta3 => new(3);
    
}