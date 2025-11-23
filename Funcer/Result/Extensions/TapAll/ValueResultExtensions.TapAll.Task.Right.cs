namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Result<IEnumerable<TValue>> result, Func<TValue, Task<Result>> next)
    {
        if (result.IsFailure) return result;

        var tapResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }

        if (tapResults.Length == 0)
        {
            return result;
        }

        return result.WithContext(tapResults[0]);
    }

    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Result<IEnumerable<TValue>> result, Func<TValue, Task> next)
    {
        if (result.IsSuccess)
        {
            await Task.WhenAll(result.Value!.Select(next));
        }

        return result;
    }

    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Result<IEnumerable<TValue>> result, Func<TValue, Task<Result<TValue2>>> next)
    {
        if (result.IsFailure) return result;

        var tapResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue>>.Failure(errors);
        }

        if (tapResults.Length == 0)
        {
            return result;
        }

        return result.WithContext(tapResults[0]);
    }
}

