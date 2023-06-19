namespace Funcer;

internal static class ResultExtensions_WithContext
{
    internal static Result WithContext(this Result result, IResult contextResult)
    {
        result.AddWarnings(contextResult.Warnings);
        return result;
    }
    
    internal static Result<TValue> WithContext<TValue>(this Result<TValue> result, IResult contextResult)
    {
        result.AddWarnings(contextResult.Warnings);
        return result;
    }
}