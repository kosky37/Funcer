namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<IEnumerable<TValue>> result)
    {
        public Result<IEnumerable<TValue>> TapAll(Func<TValue, Result> next)
        {
            if (result.IsFailure) return result;

            var tapResults = result.Value.Select(next).ToList();
            var errors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

            if (errors.Count is not 0)
            {
                return Result<IEnumerable<TValue>>.Failure(errors);
            }

            if (tapResults.Count == 0)
            {
                return result;
            }

            return result.WithContext(tapResults[0]);
        }

        public Result<IEnumerable<TValue>> TapAll(Action<TValue> next)
        {
            if (result.IsSuccess)
            {
                foreach (var item in result.Value)
                {
                    next(item);
                }
            }

            return result;
        }

        public Result<IEnumerable<TValue>> TapAll<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            if (result.IsFailure) return result;

            var tapResults = result.Value.Select(next).ToList();
            var errors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

            if (errors.Count is not 0)
            {
                return Result<IEnumerable<TValue>>.Failure(errors);
            }

            if (tapResults.Count == 0)
            {
                return result;
            }

            return result.WithContext(tapResults[0]);
        }
    }
}

