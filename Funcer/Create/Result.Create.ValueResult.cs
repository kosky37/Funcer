using Funcer.Messages;

namespace Funcer;

public partial struct Result
{
    public static Result<TValue> Create<TValue>(Func<bool> condition, TValue value, ErrorMessage error) =>
        Result<TValue>.Create(condition, value, error);

    public static Task<Result<TValue>> Create<TValue>(Func<Task<bool>> func, TValue value, ErrorMessage error) =>
        Result<TValue>.Create(func, value, error);
}