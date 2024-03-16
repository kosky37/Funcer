namespace Funcer.Tests.Common;

using Result = Funcer.Result;

public static class TestResult
{
    public static class Async
    {
        public static Task<Result> Success => Task.FromResult(Result.Success());
        public static Task<Result> Failure => Task.FromResult(Result.Failure(TestValues.Error));
    }
    
    public static Result Success => Result.Success();
    public static Result Failure => Result.Failure(TestValues.Error);

    public static class Alpha
    {
        public static class Async
        {
            public static class Success
            {
                public static Task<Result<Types.Alpha>> V1 => Task.FromResult(Result.Success(TestValues.Alpha1));
                public static Task<Result<Types.Alpha>> V2 => Task.FromResult(Result.Success(TestValues.Alpha2));
            }
            public static Task<Result<Types.Alpha>> Failure => Task.FromResult(Result.Failure<Types.Alpha>(TestValues.Error));
        }

        public static class Success
        {
            public static Result<Types.Alpha> V1 => Result.Success(TestValues.Alpha1);
            public static Result<Types.Alpha> V2 => Result.Success(TestValues.Alpha2);
        }
        
        public static Result<Types.Alpha> Failure => Result.Failure<Types.Alpha>(TestValues.Error);
    }
    
    public static class Beta
    {
        public static class Async
        {
            public static class Success
            {
                public static Task<Result<Types.Beta>> V1 => Task.FromResult(Result.Success(TestValues.Beta1));
                public static Task<Result<Types.Beta>> V2 => Task.FromResult(Result.Success(TestValues.Beta2));
                public static Task<Result<Types.Beta>> V3 => Task.FromResult(Result.Success(TestValues.Beta3));
            }
            public static Task<Result<Types.Beta>> Failure => Task.FromResult(Result.Failure<Types.Beta>(TestValues.Error));
        }
        public static class Success
        {
            public static Result<Types.Beta> V1 => Result.Success(TestValues.Beta1);
            public static Result<Types.Beta> V2 => Result.Success(TestValues.Beta2);
            public static Result<Types.Beta> V3 => Result.Success(TestValues.Beta3);
        }
        public static Result<Types.Beta> Failure => Result.Failure<Types.Beta>(TestValues.Error);
    }
}