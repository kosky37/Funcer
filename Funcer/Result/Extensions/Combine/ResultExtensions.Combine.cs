namespace Funcer;

public static partial class ResultExtensions
{
    public static Result Combine(this IEnumerable<IResult> results)
    {
        return Result.Combine(results);
    }
    
    public static Result Combine(this IEnumerable<Result> results)
    {
        return Result.Combine(results.Cast<IResult>());
    }
}

