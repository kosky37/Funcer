namespace Funcer;

public partial struct Result
{
    public static Result<IEnumerable<TValue>> Combine<TValue>(IEnumerable<Result<TValue>> results) => 
        Result<TValue>.Combine(results);
}