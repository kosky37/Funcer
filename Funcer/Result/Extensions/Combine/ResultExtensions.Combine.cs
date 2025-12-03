namespace Funcer;

public static partial class ResultExtensions
{
    extension(IEnumerable<IResult> results)
    {
        public Result Combine()
        {
            return Result.Combine(results);
        }
    }
    
    extension(IEnumerable<Result> results)
    {
        public Result Combine()
        {
            return Result.Combine(results.Cast<IResult>());
        }
    }
}

