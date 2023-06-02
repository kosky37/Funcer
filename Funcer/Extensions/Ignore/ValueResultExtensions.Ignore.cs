namespace Funcer;

public static class ValueResultExtensions_Ignore
{
    public static TResult Ignore<TResult>(this Result<TResult> result) => result.Value!;
    public static async Task<TResult> Ignore<TResult>(this Task<Result<TResult>> result) => (await result).Value!;
}