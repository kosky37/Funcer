namespace Funcer;

public readonly partial struct Result<TValue>
{
    public static Result<TValue> Success(TValue value)
    {
        return new Result<TValue>(value);
    }
}