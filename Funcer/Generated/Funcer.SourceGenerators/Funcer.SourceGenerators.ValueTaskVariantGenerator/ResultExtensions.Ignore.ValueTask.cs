namespace Funcer;

public static class ResultExtensions_Ignore_ValueTask
{
    public static ValueTask Ignore(this ValueTask<Result> result) => ValueTask.CompletedTask;
}