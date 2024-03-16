using Funcer.Messages;

namespace Funcer.Exceptions;

[Serializable]
public class FailureResultException : Exception
{
    public IEnumerable<ErrorMessage> ResultErrors { get; } = new List<ErrorMessage>();
    
    public FailureResultException() { }
    public FailureResultException(string message) : base(message) { }
    public FailureResultException(string message, Exception inner) : base(message, inner) { }
    public FailureResultException(IEnumerable<ErrorMessage> resultErrors)
    {
        ResultErrors = resultErrors;
    }
}