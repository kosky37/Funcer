namespace Funcer;

public static class ResultExtensions_Ignore_Task
{
    public static Task Ignore(this Task<Result> result) => Task.CompletedTask;
}