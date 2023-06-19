using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Log
{
    public static Result Log(this Result result, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);

        return result;
    }
    
    public static Result Log(this Result result, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        
        return result;
    }
}