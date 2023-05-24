namespace Funcer.Tests.Common;

public static class Tasks
{
    public static class Returns
    {
        public static Func<Task> Nothing => () => Task.CompletedTask;
        public static Func<Task<Types.Alpha>> Alpha1 => () => Task.FromResult(Values.Alpha1);
    }
    
    public static class Takes
    {
        public static class Alpha
        {
            public static class Returns
            {
                public static Func<Types.Alpha, Task> Nothing => _ => Task.CompletedTask;
                public static Func<Types.Alpha, Task<Types.Alpha>> Alpha1 => _ => Task.FromResult(Values.Alpha1);
            }
        }
        
        public static class Beta
        {
            public static class Returns
            {
                public static Func<Types.Beta, Task> Nothing => _ => Task.CompletedTask;
                public static Func<Types.Beta, Task<Types.Alpha>> Alpha1 => _ => Task.FromResult(Values.Alpha1);
            }
        }
    }
}