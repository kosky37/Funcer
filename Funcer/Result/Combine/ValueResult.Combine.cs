namespace Funcer;

public readonly partial struct Result
{
#if NET9_0_OR_GREATER
    public static Result<IEnumerable<TValue>> Combine<TValue>(params IEnumerable<Result<TValue>> results)
#else
    public static Result<IEnumerable<TValue>> Combine<TValue>(params Result<TValue>[] results)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Any() 
            ? Result<IEnumerable<TValue>>.Failure(errors) 
            : Result.Success(resultsList.Select(x => x.Value!));
    }
    
    public static Result<IEnumerable<TValue>> Combine<TValue>(IEnumerable<Result<TValue>> results)
#endif
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Any() 
            ? Result<IEnumerable<TValue>>.Failure(errors) 
            : Result.Success(resultsList.Select(x => x.Value!));
    }
}