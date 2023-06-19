namespace Funcer;

//TODO: create generator
public static class ValueResultExtensions_Map_Tuple
{
    public static Result<TValue> Map<TValue1, TValue2, TValue>(this Result<(TValue1, TValue2)> result, Func<TValue1, TValue2, Result<TValue>> next)
    {
        return next(result.Value!.Item1, result.Value!.Item2);
    }
}