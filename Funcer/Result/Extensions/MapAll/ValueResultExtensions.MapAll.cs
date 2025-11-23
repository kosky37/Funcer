namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<IEnumerable<TMappedValue>> MapAll<TValue, TMappedValue>(this IEnumerable<Result<TValue>> results, Func<TValue, Result<TMappedValue>> mapper)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TMappedValue>>.Failure(errors);
        }
        
        var mappedResults = resultsList.Select(x => mapper(x.Value!)).ToList();
        var mappedErrors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        return mappedErrors.Count is not 0
            ? Result<IEnumerable<TMappedValue>>.Failure(mappedErrors)
            : Result.Success(mappedResults.Select(x => x.Value!));
    }
    
    public static Result<IEnumerable<TMappedValue>> MapAll<TValue, TMappedValue>(this IEnumerable<Result<TValue>> results, Func<TValue, TMappedValue> mapper)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        return errors.Count is not 0
            ? Result<IEnumerable<TMappedValue>>.Failure(errors)
            : Result.Success(resultsList.Select(x => mapper(x.Value!)));
    }
}

