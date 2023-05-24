namespace Funcer;

public partial class Result
{
    public static Result<IEnumerable<TValue>> Combine<TValue>(IEnumerable<Result<TValue>> results) => 
        Result<TValue>.Combine(results);
}