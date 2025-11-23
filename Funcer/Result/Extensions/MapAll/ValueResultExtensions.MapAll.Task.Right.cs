namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this IEnumerable<Result<TValue>> results, Func<TValue, Task<Result<TMappedValue>>> mapper)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TMappedValue>>.Failure(errors);
        }
        
        var mappedResults = await Task.WhenAll(resultsList.Select(x => mapper(x.Value!)));
        var mappedErrors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        return mappedErrors.Count is not 0
            ? Result<IEnumerable<TMappedValue>>.Failure(mappedErrors)
            : Result.Success(mappedResults.Select(x => x.Value!));
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this IEnumerable<Result<TValue>> results, Func<TValue, Task<TMappedValue>> mapper)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TMappedValue>>.Failure(errors);
        }
        
        var mappedValues = await Task.WhenAll(resultsList.Select(x => mapper(x.Value!)));
        return Result.Success<IEnumerable<TMappedValue>>(mappedValues);
    }
}

