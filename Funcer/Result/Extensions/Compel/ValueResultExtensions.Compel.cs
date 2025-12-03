using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public TValue Compel()
        {
            if (result.IsFailure) throw new FailureResultException(result.Errors);

            return result.Value!;
        }

        public TValue Compel(Func<IReadOnlyCollection<ErrorMessage>, Exception> exception)
        {
            if (result.IsFailure) throw exception(result.Errors);

            return result.Value!;
        }
    }
}