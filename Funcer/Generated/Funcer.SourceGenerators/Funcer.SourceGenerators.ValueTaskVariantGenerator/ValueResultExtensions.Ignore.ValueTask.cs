namespace Funcer;

public static class ValueResultExtensions_Ignore_ValueTask
{
    public static async ValueTask<TResult> Ignore<TResult>(this ValueTask<Result<TResult>> result) => (await result).Value!;
}