namespace Funcer;

internal static class InternalResultExtensions
{
    internal static Result WithContext(this Result result, IResult contextResult)
    {
        return result.WithWarnings(contextResult.Warnings);
    }
    
    internal static Result<TValue> WithContext<TValue>(this Result<TValue> result, IResult contextResult)
    {
        return result.WithWarnings(contextResult.Warnings);
    }
}