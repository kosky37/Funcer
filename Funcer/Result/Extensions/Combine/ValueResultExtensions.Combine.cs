using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result Combine<TValue>(this Result<TValue> result, params IResult[] others)
    {
        var allResults = new List<IResult> { result };
        allResults.AddRange(others);
        
        return Result.Combine(allResults);
    }
    
    public static Result Combine<TValue>(this Result<TValue> result, params Result[] others)
    {
        var allResults = new List<IResult> { result };
        allResults.AddRange(others.Cast<IResult>());
        
        return Result.Combine(allResults);
    }
    
    public static Result<IEnumerable<TValue>> Combine<TValue>(this Result<TValue> result, params Result<TValue>[] others)
    {
        var allResults = new List<Result<TValue>> { result };
        allResults.AddRange(others);
        
        return Result.Combine(allResults);
    }
    
    public static Result<IEnumerable<TOther>> Combine<TValue, TOther>(this Result<TValue> result, params Result<TOther>[] others)
    {
        var allResults = new List<IResult> { result };
        allResults.AddRange(others.Cast<IResult>());
        
        var errors = allResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TOther>>.Failure(errors);
        }
        
        return Result.Success(others.Select(x => x.Value!));
    }
    
    public static Result<IEnumerable<TValue>> Combine<TValue>(this IEnumerable<Result<TValue>> results)
    {
        return Result.Combine(results);
    }
}

