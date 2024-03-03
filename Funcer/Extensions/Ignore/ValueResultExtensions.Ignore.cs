namespace Funcer;

public static class ValueResultExtensions_Ignore
{
    public static TResult Ignore<TResult>(this Result<TResult> result) => result.Value!;
}