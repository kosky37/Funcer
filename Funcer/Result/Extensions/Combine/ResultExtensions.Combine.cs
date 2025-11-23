namespace Funcer;

public static partial class ResultExtensions
{
    public static Result Combine(this Result result, params IResult[] others)
    {
        var allResults = new List<IResult> { result };
        allResults.AddRange(others);
        
        return Result.Combine(allResults);
    }
    
    public static Result Combine(this Result result, params Result[] others)
    {
        var allResults = new List<IResult> { result };
        allResults.AddRange(others.Cast<IResult>());
        
        return Result.Combine(allResults);
    }
    
    public static Result<IEnumerable<TValue>> Combine<TValue>(this Result result, params Result<TValue>[] others)
    {
        var allResults = new List<IResult> { result };
        allResults.AddRange(others.Cast<IResult>());
        
        var errors = allResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();
        
        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }
        
        return Result.Success(others.Select(x => x.Value!));
    }
    
    public static Result Combine(this IEnumerable<IResult> results)
    {
        return Result.Combine(results);
    }
    
    public static Result Combine(this IEnumerable<Result> results)
    {
        return Result.Combine(results.Cast<IResult>());
    }
}

