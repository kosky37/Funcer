namespace Funcer.Tests.Common;

using Result = Funcer.Result;

public static class AsyncFunc
{
    public static class Returns
    {
        public static Func<Task> Void => () => Task.CompletedTask;
        public static Func<Task<Types.Alpha>> Alpha1 => () => Task.FromResult(Values.Alpha1);
        public static Func<Task<Types.Beta>> Beta1 => () => Task.FromResult(Values.Beta1);
        public static class Success
        {
            public static Func<Task<Result>> Empty => () => Task.FromResult(TestResult.Success);
            public static Func<Task<Result<Types.Alpha>>> Alpha1 => () => Task.FromResult(TestResult.Alpha.Success.V1);
            public static Func<Task<Result<Types.Beta>>> Beta1 => () => Task.FromResult(TestResult.Beta.Success.V1);
        }
        public static class Failure
        {
            public static Func<Task<Result>> Empty => () => Task.FromResult(TestResult.Failure);
            public static Func<Task<Result<Types.Alpha>>> Alpha => () => Task.FromResult(TestResult.Alpha.Failure);
            public static Func<Task<Result<Types.Beta>>> Beta => () => Task.FromResult(TestResult.Beta.Failure);
        }
        public static Func<Task<bool>> False => () => Task.FromResult(false);
        public static Func<Task<bool>> True => () => Task.FromResult(true);
        public static Task<Exception> ArgumentException => Task.FromResult<Exception>(new ArgumentException());
    }
    
    public static class Takes
    {
        public static class Alpha
        {
            public static class Returns
            {
                public static Func<Types.Alpha, Task> Nothing => _ => Task.CompletedTask;
                public static Func<Types.Alpha, Task<Types.Alpha>> Alpha1 => _ => Task.FromResult(Values.Alpha1);
                public static class Success
                {
                    public static Func<Types.Alpha, Task<Result>> Empty => _ => Task.FromResult(TestResult.Success);
                    public static Func<Types.Alpha, Task<Result<Types.Beta>>> Beta1 => _ => Task.FromResult(TestResult.Beta.Success.V1);
                }
                public static class Failure
                {
                    public static Func<Types.Alpha, Task<Result>> Empty => _ => Task.FromResult(TestResult.Failure);
                    public static Func<Types.Alpha, Task<Result<Types.Beta>>> Beta => _ => Task.FromResult(TestResult.Beta.Failure);
                }
                
                public static Func<Types.Alpha, Task<bool>> IsFalse => x => Task.FromResult(x.Value is false);
                public static Func<Types.Alpha, Task<bool>> IsTrue => x => Task.FromResult(x.Value);
            }
        }
        
        public static class Beta
        {
            public static class Returns
            {
                public static Func<Types.Beta, Task> Nothing => _ => Task.CompletedTask;
                public static Func<Types.Beta, Task<Types.Alpha>> Alpha1 => _ => Task.FromResult(Values.Alpha1);
                public static class Success
                {
                    public static Func<Types.Beta, Task<Result<Types.Alpha>>> Alpha1 => _ => Task.FromResult(TestResult.Alpha.Success.V1);
                }
                public static class Failure
                {
                    public static Func<Types.Beta, Task<Result<Types.Alpha>>> Alpha => _ => Task.FromResult(TestResult.Alpha.Failure);
                }
            }
        }
    }
}