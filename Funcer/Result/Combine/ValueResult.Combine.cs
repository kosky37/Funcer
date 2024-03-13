namespace Funcer;

public readonly partial struct Result
{
    public static Result<IEnumerable<TValue>> Combine<TValue>(IEnumerable<Result<TValue>> results)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Any() 
            ? Result<IEnumerable<TValue>>.Failure(errors) 
            : Result.Success(resultsList.Select(x => x.Value!));
    }
}