namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValueList, TValue>(Result<TValueList> result)
        where TValueList : IEnumerable<TValue>
    {
        public Result<IEnumerable<TValue2>> MapAll<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            if (result.IsFailure)
            {
                return Result<IEnumerable<TValue2>>.Failure(result.Errors);
            }

            var mappedResults = result.Value!.Select(next).ToList();
            var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

            if (errors.Count is not 0)
            {
                return Result<IEnumerable<TValue2>>.Failure(errors);
            }

            return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
        }

        public Result<IEnumerable<TValue2>> MapAll<TValue2>(Func<TValue, TValue2> next)
        {
            if (result.IsFailure)
            {
                return Result<IEnumerable<TValue2>>.Failure(result.Errors);
            }

            return Result.Success(result.Value!.Select(next)).WithContext(result);
        }
    }
}
