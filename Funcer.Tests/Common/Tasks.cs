
namespace Funcer.Tests.Common;

public static class Tasks
{
    public static class Returns
    {
        public static Func<Task> Nothing => () => Task.CompletedTask;
        public static Func<Task<Types.Alpha>> Alpha1 => () => Task.FromResult(Values.Alpha1);
        public static Func<Task<Types.Beta>> Beta1 => () => Task.FromResult(Values.Beta1);
        public static class Success
        {
            public static Func<Task<Result>> Empty => () => Task.FromResult(Results.Success.Nothing);
            public static Func<Task<Result<Types.Alpha>>> Alpha1 => () => Task.FromResult(Results.Success.Alpha1);
            public static Func<Task<Result<Types.Beta>>> Beta1 => () => Task.FromResult(Results.Success.Beta1);
        }
        public static class Failure
        {
            public static Func<Task<Result>> Empty => () => Task.FromResult(Results.Failure.Nothing);
            public static Func<Task<Result<Types.Alpha>>> Alpha => () => Task.FromResult(Results.Failure.Alpha);
            public static Func<Task<Result<Types.Beta>>> Beta => () => Task.FromResult(Results.Failure.Beta);
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
                    public static Func<Types.Alpha, Task<Result>> Empty => _ => Task.FromResult(Results.Success.Nothing);
                    public static Func<Types.Alpha, Task<Result<Types.Beta>>> Beta1 => _ => Task.FromResult(Results.Success.Beta1);
                }
                public static class Failure
                {
                    public static Func<Types.Alpha, Task<Result>> Empty => _ => Task.FromResult(Results.Failure.Nothing);
                    public static Func<Types.Alpha, Task<Result<Types.Beta>>> Beta => _ => Task.FromResult(Results.Failure.Beta);
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
                    public static Func<Types.Beta, Task<Result<Types.Alpha>>> Alpha1 => _ => Task.FromResult(Results.Success.Alpha1);
                }
                public static class Failure
                {
                    public static Func<Types.Beta, Task<Result<Types.Alpha>>> Alpha => _ => Task.FromResult(Results.Failure.Alpha);
                }
            }
        }
    }
}