using Funcer.Messages;

namespace Funcer;

public partial struct Result
{
    public static Result Create(bool condition, ErrorMessage error)
    {
        return condition ? Success() : Failure(error);
    }
    
    public static Result Create(Func<bool> condition, ErrorMessage error)
    {
        return condition() ? Success() : Failure(error);
    }

    public static async Task<Result> Create(Func<Task<bool>> condition, ErrorMessage error)
    {
        return await condition() ? Success() : Failure(error);
    }

    public static async ValueTask<Result> Create(Func<ValueTask<bool>> condition, ErrorMessage error)
    {
        return await condition() ? Success() : Failure(error);
    }
}