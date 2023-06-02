namespace Funcer;

[Serializable]
public class FailureResultException : Exception
{
    public IList<Error> ResultErrors { get; } = new List<Error>();
    
    public FailureResultException() { }
    public FailureResultException(string message) : base(message) { }
    public FailureResultException(string message, Exception inner) : base(message, inner) { }
    public FailureResultException(IList<Error> resultErrors)
    {
        ResultErrors = resultErrors;
    }
}