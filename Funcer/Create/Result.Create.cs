using Funcer.Messages;

namespace Funcer;

public partial class Result
{
    public static Result Create(bool condition, Error error)
    {
        return condition ? Success() : Failure(error);
    }
    
    public static Result Create(Func<bool> condition, Error error)
    {
        return condition() ? Success() : Failure(error);
    }

    public static async Task<Result> Create(Func<Task<bool>> condition, Error error)
    {
        return await condition() ? Success() : Failure(error);
    }

    public static async ValueTask<Result> Create(Func<ValueTask<bool>> condition, Error error)
    {
        return await condition() ? Success() : Failure(error);
    }
}