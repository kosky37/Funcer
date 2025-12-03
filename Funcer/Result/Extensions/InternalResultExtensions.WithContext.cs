namespace Funcer;

internal static class InternalResultExtensions
{
    extension(Result result)
    {
        internal Result WithContext(IResult contextResult)
        {
            return result.WithWarnings(contextResult.Warnings);
        }
    }
    
    extension<TValue>(Result<TValue> result)
    {
        internal Result<TValue> WithContext(IResult contextResult)
        {
            return result.WithWarnings(contextResult.Warnings);
        }
    }
}