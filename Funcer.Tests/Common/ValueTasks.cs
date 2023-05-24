namespace Funcer.Tests.Common;

public static class ValueTasks
{
    public static class Returns
    {
        public static Func<ValueTask> Nothing => () => ValueTask.CompletedTask;
        public static Func<ValueTask<Types.Alpha>> Alpha1 => () => ValueTask.FromResult(Values.Alpha1);
    }
    
    public static class Takes
    {
        public static class Alpha
        {
            public static class Returns
            {
                public static Func<Types.Alpha, ValueTask> Nothing => _ => ValueTask.CompletedTask;
                public static Func<Types.Alpha, ValueTask<Types.Alpha>> Alpha1 => _ => ValueTask.FromResult(Values.Alpha1);
            }
        }
        
        public static class Beta
        {
            public static class Returns
            {
                public static Func<Types.Beta, ValueTask> Nothing => _ => ValueTask.CompletedTask;
                public static Func<Types.Beta, ValueTask<Types.Alpha>> Alpha1 => _ => ValueTask.FromResult(Values.Alpha1);
            }
        }
    }
}