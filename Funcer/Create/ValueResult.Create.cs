using Funcer.Messages;

namespace Funcer;

public partial struct Result<TValue>
{
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
    
    public static async ValueTask<Result<TValue>> Create(Func<ValueTask<bool>> func, TValue value, ErrorMessage error)
    {
        var isSuccess = await func();
        return isSuccess ? Success(value) : Failure(error);
    }
}