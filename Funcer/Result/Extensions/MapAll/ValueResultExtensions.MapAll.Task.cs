namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<IEnumerable<TValue>>> resultTask)
    {
        public async Task<Result<IEnumerable<TValue2>>> MapAll<TValue2>(Func<TValue, Task<Result<TValue2>>> next)
        {
            var result = await resultTask;
            if (result.IsFailure)
            {
                return Result<IEnumerable<TValue2>>.Failure(result.Errors);
            }

            var mappedResults = await Task.WhenAll(result.Value!.Select(next));
            var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

            if (errors.Count is not 0)
            {
                return Result<IEnumerable<TValue2>>.Failure(errors);
            }

            return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
        }

        public async Task<Result<IEnumerable<TValue2>>> MapAll<TValue2>(Func<TValue, Task<TValue2>> next)
        {
            var result = await resultTask;
            if (result.IsFailure)
            {
                return Result<IEnumerable<TValue2>>.Failure(result.Errors);
            }

            var mappedValues = await Task.WhenAll(result.Value!.Select(next));
            return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
        }
    }
}

