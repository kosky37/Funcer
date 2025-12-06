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

    public static class Bool
    {
        public static class Async
        {
            public static Task<Result<bool>> SuccessTrue => Task.FromResult(Result.Success(true));
            public static Task<Result<bool>> SuccessFalse => Task.FromResult(Result.Success(false));
            public static Task<Result<bool>> Failure => Task.FromResult(Result.Failure<bool>(TestValues.Error));
        }

        public static Result<bool> SuccessTrue => Result.Success(true);
        public static Result<bool> SuccessFalse => Result.Success(false);
        public static Result<bool> Failure => Result.Failure<bool>(TestValues.Error);
    }

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
    
    public static class AlphaEnumerable
    {
        public static class Async
        {
            public static class Success
            {
                public static Task<Result<IEnumerable<Types.Alpha>>> V1V2 => Task.FromResult(Result.Success(new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable()));
                public static Task<Result<IEnumerable<Types.Alpha>>> Empty => Task.FromResult(Result.Success(Array.Empty<Types.Alpha>().AsEnumerable()));
            }
            public static Task<Result<IEnumerable<Types.Alpha>>> Failure => Task.FromResult(Result.Failure<IEnumerable<Types.Alpha>>(TestValues.Error));
        }

        public static class Success
        {
            public static Result<IEnumerable<Types.Alpha>> V1V2 => Result.Success(new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable());
            public static Result<IEnumerable<Types.Alpha>> Empty => Result.Success(Array.Empty<Types.Alpha>().AsEnumerable());
        }
        
        public static Result<IEnumerable<Types.Alpha>> Failure => Result.Failure<IEnumerable<Types.Alpha>>(TestValues.Error);
    }
    
    public static class BetaEnumerable
    {
        public static class Async
        {
            public static class Success
            {
                public static Task<Result<IEnumerable<Types.Beta>>> V1V2 => Task.FromResult(Result.Success(new[] { TestValues.Beta1, TestValues.Beta2 }.AsEnumerable()));
                public static Task<Result<IEnumerable<Types.Beta>>> Empty => Task.FromResult(Result.Success(Array.Empty<Types.Beta>().AsEnumerable()));
            }
            public static Task<Result<IEnumerable<Types.Beta>>> Failure => Task.FromResult(Result.Failure<IEnumerable<Types.Beta>>(TestValues.Error));
        }

        public static class Success
        {
            public static Result<IEnumerable<Types.Beta>> V1V2 => Result.Success(new[] { TestValues.Beta1, TestValues.Beta2 }.AsEnumerable());
            public static Result<IEnumerable<Types.Beta>> Empty => Result.Success(Array.Empty<Types.Beta>().AsEnumerable());
        }
        
        public static Result<IEnumerable<Types.Beta>> Failure => Result.Failure<IEnumerable<Types.Beta>>(TestValues.Error);
    }
}