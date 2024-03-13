namespace Funcer;

public static partial class ResultExtensions
{
    public static Result MapIf(this Result result, bool condition, Func<Result> next)
    {
        return result.IsFailure || !condition ? result : next().WithContext(result);
    }
    
    public static Result MapIf(this Result result, Func<bool> condition, Func<Result> next)
    {
        return result.IsFailure || !condition() ? result : next().WithContext(result);
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