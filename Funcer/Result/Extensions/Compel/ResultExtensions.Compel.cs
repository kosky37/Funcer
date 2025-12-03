using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public void Compel()
        {
            if (result.IsFailure) throw new FailureResultException(result.Errors);
        }

        public void Compel(Func<IReadOnlyCollection<ErrorMessage>, Exception> exception)
        {
            if (result.IsFailure) throw exception(result.Errors);
        }
    }
}