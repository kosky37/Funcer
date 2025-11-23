namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<IEnumerable<TValue>> TapAll<TValue>(this IEnumerable<Result<TValue>> results, Func<TValue, Result> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        var tapResults = resultsList.Select(x => tap(x.Value!)).ToList();
        var tapErrors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        return tapErrors.Count is not 0
            ? Result<IEnumerable<TValue>>.Failure(tapErrors)
            : Result.Success<IEnumerable<TValue>>(resultsList.Select(x => x.Value!));
    }
    
    public static Result<IEnumerable<TValue>> TapAll<TValue>(this IEnumerable<Result<TValue>> results, Action<TValue> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        foreach (var result in resultsList)
        {
            tap(result.Value!);
        }
        
        return Result.Success<IEnumerable<TValue>>(resultsList.Select(x => x.Value!));
    }
    
    public static Result<IEnumerable<TValue>> TapAll<TValue>(this IEnumerable<Result<TValue>> results, Action tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        tap();
        
        return Result.Success<IEnumerable<TValue>>(resultsList.Select(x => x.Value!));
    }
    
    public static Result<IEnumerable<TValue>> TapAll<TValue, TValue2>(this IEnumerable<Result<TValue>> results, Func<TValue, Result<TValue2>> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        var tapResults = resultsList.Select(x => tap(x.Value!)).ToList();
        var tapErrors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        return tapErrors.Count is not 0
            ? Result<IEnumerable<TValue>>.Failure(tapErrors)
            : Result.Success<IEnumerable<TValue>>(resultsList.Select(x => x.Value!));
    }
    
    public static Result<IEnumerable<TValue>> TapAll<TValue, TValue2>(this IEnumerable<Result<TValue>> results, Func<TValue, TValue2> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        foreach (var result in resultsList)
        {
            tap(result.Value!);
        }
        
        return Result.Success<IEnumerable<TValue>>(resultsList.Select(x => x.Value!));
    }
    
    public static Result<IEnumerable<TValue>> TapAll<TValue, TValue2>(this IEnumerable<Result<TValue>> results, Func<TValue2> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        tap();
        
        return Result.Success<IEnumerable<TValue>>(resultsList.Select(x => x.Value!));
    }
    
    public static Result<IEnumerable<TValue>> TapAll<TValue>(this IEnumerable<Result<TValue>> results, Func<Result<TValue>> tap)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        var tapResult = tap();
        if (tapResult.IsFailure)
        {
            return Result<IEnumerable<TValue>>.Failure(tapResult.Errors);
        }
        
        return Result.Success<IEnumerable<TValue>>(resultsList.Select(x => x.Value!));
    }
}

