namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Result<TValue>> results, Func<TValue, Task<Result>> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        var tapResults = await Task.WhenAll(resultsList.Select(x => tap(x.Value!)));
        var tapErrors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        return tapErrors.Count is not 0
            ? Result<IEnumerable<TValue>>.Failure(tapErrors)
            : Result.Success(resultsList.Select(x => x.Value!));
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Result<TValue>> results, Func<TValue, Task> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        await Task.WhenAll(resultsList.Select(x => tap(x.Value!)));
        
        return Result.Success(resultsList.Select(x => x.Value!));
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Result<TValue>> results, Func<Task> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        await tap();
        
        return Result.Success(resultsList.Select(x => x.Value!));
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this IEnumerable<Result<TValue>> results, Func<TValue, Task<Result<TValue2>>> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        var tapResults = await Task.WhenAll(resultsList.Select(x => tap(x.Value!)));
        var tapErrors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        return tapErrors.Count is not 0
            ? Result<IEnumerable<TValue>>.Failure(tapErrors)
            : Result.Success(resultsList.Select(x => x.Value!));
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this IEnumerable<Result<TValue>> results, Func<TValue, Task<TValue2>> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        await Task.WhenAll(resultsList.Select(x => tap(x.Value!)));
        
        return Result.Success(resultsList.Select(x => x.Value!));
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this IEnumerable<Result<TValue>> results, Func<Task<TValue2>> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        await tap();
        
        return Result.Success(resultsList.Select(x => x.Value!));
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Result<TValue>> results, Func<Task<Result<TValue>>> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        var tapResult = await tap();
        if (tapResult.IsFailure)
        {
            return Result<IEnumerable<TValue>>.Failure(tapResult.Errors);
        }
        
        return Result.Success(resultsList.Select(x => x.Value!));
    }
}

