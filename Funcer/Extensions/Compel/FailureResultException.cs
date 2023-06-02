using Funcer.Messages;

namespace Funcer;

[Serializable]
public class FailureResultException : Exception
{
    public IEnumerable<Error> ResultErrors { get; } = new List<Error>();
    
    public FailureResultException() { }
    public FailureResultException(string message) : base(message) { }
    public FailureResultException(string message, Exception inner) : base(message, inner) { }
    public FailureResultException(IEnumerable<Error> resultErrors)
    {
        ResultErrors = resultErrors;
    }
}