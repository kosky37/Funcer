namespace Funcer;

public partial class Result<TValue>
{
    public static Result<IEnumerable<TValue>> Combine(IEnumerable<Result<TValue>> results)
    {
        var resultsList = results.ToList();
        var errors = resultsList.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Any() 
            ? Result<IEnumerable<TValue>>.Failure(errors) 
            : Result.Success(resultsList.Select(x => x.Value!));
    }
}