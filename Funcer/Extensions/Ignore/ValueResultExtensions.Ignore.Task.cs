namespace Funcer;

public static class ValueResultExtensions_Ignore_Task
{
    public static async Task<TResult> Ignore<TResult>(this Task<Result<TResult>> result) => (await result).Value!;
}