using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static void Compel(this Result result)
    {
        if (result.IsFailure) throw new FailureResultException(result.Errors);
    }
    
    public static void Compel(this Result result, Func<IReadOnlyCollection<ErrorMessage>, Exception> exception)
    {
        if (result.IsFailure) throw exception(result.Errors);
    }
}