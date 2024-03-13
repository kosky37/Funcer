namespace Funcer.Tests.Common;

using Result = Funcer.Result;

public static class TestResult
{
    public static class Async
    {
        public static Task<Result> Success => Task.FromResult(Result.Success());
        public static Task<Result> Failure => Task.FromResult(Result.Failure(Values.TestError));
    }
    
    public static Result Success => Result.Success();
    public static Result Failure => Result.Failure(Values.TestError);

    public static class Alpha
    {
        public static class Async
        {
            public static class Success
            {
                public static Task<Result<Types.Alpha>> V1 => Task.FromResult(Result.Success(Values.Alpha1));
                public static Task<Result<Types.Alpha>> V2 => Task.FromResult(Result.Success(Values.Alpha2));
            }
            public static Task<Result<Types.Alpha>> Failure => Task.FromResult(Result.Failure<Types.Alpha>(Values.TestError));
        }

        public static class Success
        {
            public static Result<Types.Alpha> V1 => Result.Success(Values.Alpha1);
            public static Result<Types.Alpha> V2 => Result.Success(Values.Alpha2);
        }
        
        public static Result<Types.Alpha> Failure => Result.Failure<Types.Alpha>(Values.TestError);
    }
    
    public static class Beta
    {
        public static class Async
        {
            public static class Success
            {
                public static Task<Result<Types.Beta>> V1 => Task.FromResult(Result.Success(Values.Beta1));
                public static Task<Result<Types.Beta>> V2 => Task.FromResult(Result.Success(Values.Beta2));
                public static Task<Result<Types.Beta>> V3 => Task.FromResult(Result.Success(Values.Beta3));
            }
            public static Task<Result<Types.Beta>> Failure => Task.FromResult(Result.Failure<Types.Beta>(Values.TestError));
        }
        public static class Success
        {
            public static Result<Types.Beta> V1 => Result.Success(Values.Beta1);
            public static Result<Types.Beta> V2 => Result.Success(Values.Beta2);
            public static Result<Types.Beta> V3 => Result.Success(Values.Beta3);
        }
        public static Result<Types.Beta> Failure => Result.Failure<Types.Beta>(Values.TestError);
    }
}