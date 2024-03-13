using Funcer.Messages;

namespace Funcer;

public readonly partial struct Result<TValue>
{
    public static Result<TValue> Create(bool condition, TValue value, ErrorMessage error)
    {
        return condition ? Success(value) : Failure(error);
    }
    
    public static Result<TValue> Create(Func<bool> func, TValue value, ErrorMessage error)
    {
        var isSuccess = func();
        return isSuccess ? Success(value) : Failure(error);
    }
    
    public static async Task<Result<TValue>> Create(Func<Task<bool>> func, TValue value, ErrorMessage error)
    {
        var isSuccess = await func();
        return isSuccess ? Success(value) : Failure(error);
    }
}