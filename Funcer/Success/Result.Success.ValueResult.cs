namespace Funcer;

public partial class Result
{
    public static Result<TValue> Success<TValue>(TValue value)
    {
        return Result<TValue>.Success(value);
    }
}