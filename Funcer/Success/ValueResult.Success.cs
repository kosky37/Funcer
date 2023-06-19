namespace Funcer;

public partial struct Result<TValue>
{
    public static Result<TValue> Success(TValue value)
    {
        return new Result<TValue>(value);
    }
}