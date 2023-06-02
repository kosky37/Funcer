namespace Funcer;

public static class ResultExtensions_MapIf
{
    public static Result MapIf(this Result result, bool condition, Func<Result> next)
    {
        return result.IsFailure || !condition ? result : next();
    }
    
    public static Result MapIf(this Result result, Func<bool> condition, Func<Result> next)
    {
        return result.IsFailure || !condition() ? result : next();
    }

    public static Result MapIf(this Result result, bool condition, Action next)
    {
        if (result.IsSuccess && condition) next();

        return result;
    }
    
    public static Result MapIf(this Result result, Func<bool> condition, Action next)
    {
        if (result.IsSuccess && condition()) next();

        return result;
    }
}