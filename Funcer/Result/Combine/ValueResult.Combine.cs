namespace Funcer;

public readonly partial struct Result
{
    public static Result<IEnumerable<TValue>> Combine<TValue>(params IEnumerable<Result<TValue>> results)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Count is not 0
            ? Result<IEnumerable<TValue>>.Failure(errors) 
            : Success(resultsList.Select(x => x.Value!));
    }
}