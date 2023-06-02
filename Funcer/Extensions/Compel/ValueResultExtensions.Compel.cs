namespace Funcer;

public static class ValueResultExtensions_Compel
{
    public static TResult Compel<TResult>(this Result<TResult> result)
    {
        if (result.IsFailure) throw new FailureResultException(result.Errors);

        return result.Value!;
    }
    
    public static TResult Compel<TResult>(this Result<TResult> result, Func<IList<Error>, Exception> exception)
    {
        if (result.IsFailure) throw exception(result.Errors);

        return result.Value!;
    }
}