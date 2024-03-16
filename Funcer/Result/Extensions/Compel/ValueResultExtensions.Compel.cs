using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static TValue Compel<TValue>(this Result<TValue> result)
    {
        if (result.IsFailure) throw new FailureResultException(result.Errors);

        return result.Value!;
    }
    
    public static TValue Compel<TValue>(this Result<TValue> result, Func<IReadOnlyCollection<ErrorMessage>, Exception> exception)
    {
        if (result.IsFailure) throw exception(result.Errors);

        return result.Value!;
    }
}