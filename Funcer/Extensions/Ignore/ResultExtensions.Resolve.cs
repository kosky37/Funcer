namespace Funcer;

public static partial class ResultExtensions
{
    public static void Ignore(this Result result) { }
    public static Task Ignore(this Task<Result> result) => Task.CompletedTask;
    public static ValueTask Ignore(this ValueTask<Task<Result>> result) => ValueTask.CompletedTask;
}