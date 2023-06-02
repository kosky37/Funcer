using Funcer.Generator.Attributes;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Ignore_Task
{
    public static Task Ignore(this Task<Result> result) => Task.CompletedTask;
}