namespace Funcer;

internal static class BaseResultExtensions_Internal
{
    internal static TResult WithContext<TResult>(this TResult result, BaseResult contextResult)
        where TResult : BaseResult
    {
        result.AddWarnings(contextResult.Warnings);
        return result;
    }
}