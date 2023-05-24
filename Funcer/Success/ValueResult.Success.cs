namespace Funcer;

public partial class Result<TValue>
{
    public static Result<TValue> Success(TValue value)
    {
        return new Result<TValue>(value);
    }
}