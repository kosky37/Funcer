namespace Funcer.Tests.Common;

public static class FunctionsOld
{
    public static class Bool
    {
        public static Func<Types.Alpha, bool> IsFalse => x => x.Value is false;
        public static Func<Types.Alpha, bool> IsTrue => x => x.Value;
    }
    
    public static class True
    {
        public static Func<bool> WithDefault => () => true;
        public static Func<Task<bool>> WithTask => () => Task.FromResult(true);
        public static Func<ValueTask<bool>> WithValueTask => () => ValueTask.FromResult(true);
    }
    
    public static class False
    {
        public static Func<bool> WithDefault => () => false;
        public static Func<Task<bool>> WithTask => () => Task.FromResult(false);
        public static Func<ValueTask<bool>> WithValueTask => () => ValueTask.FromResult(false);
    }
    
    public static class Success
    {
        public static class WithDefault
        {
            public static Func<Result> Void => () => Results.Success.Nothing;
            public static Func<Result<Types.Alpha>> Alpha => () => Results.Success.Alpha1;
            public static Func<Result<Types.Beta>> Beta => () => Results.Success.Beta1;
            public static Func<Types.Beta, Result<Types.Alpha>> AlphaWithBetaParam => _ => Results.Success.Alpha1;
            public static Func<Types.Alpha, Result<Types.Beta>> BetaWithAlphaParam => _ => Results.Success.Beta1;
            public static Func<Types.Alpha, Result> VoidWithAlphaParam => _ => Results.Success.Nothing;
        }

        public static class WithTask
        {
            public static Func<Task<Result>> Void => () => Task.FromResult(Results.Success.Nothing);
            public static Func<Task<Result<Types.Alpha>>> Alpha => () => Task.FromResult(Results.Success.Alpha1);
            public static Func<Task<Result<Types.Beta>>> Beta => () => Task.FromResult(Results.Success.Beta1);
            public static Func<Types.Beta, Task<Result<Types.Alpha>>> AlphaWithBetaParam => _ => Task.FromResult(Results.Success.Alpha1);
            public static Func<Types.Alpha, Task<Result>> VoidWithAlphaParam => _ => Task.FromResult(Results.Success.Nothing);
        }

        public static class WithValueTask
        {
            public static Func<ValueTask<Result>> Void => () => ValueTask.FromResult(Results.Success.Nothing);
            public static Func<ValueTask<Result<Types.Alpha>>> Alpha => () => ValueTask.FromResult(Results.Success.Alpha1);
            public static Func<ValueTask<Result<Types.Beta>>> Beta => () => ValueTask.FromResult(Results.Success.Beta1);
            public static Func<Types.Beta, ValueTask<Result<Types.Alpha>>> AlphaWithBetaParam => _ => ValueTask.FromResult(Results.Success.Alpha1);
            public static Func<Types.Alpha, ValueTask<Result>> VoidWithAlphaParam => _ => ValueTask.FromResult(Results.Success.Nothing);
        }
    }

    public static class Failure
    {
        public static class WithDefault
        {
            public static Func<Result> Void => () => Results.Failure.Nothing;
            public static Func<Result<Types.Alpha>> Alpha => () => Results.Failure.Alpha;
            public static Func<Result<Types.Beta>> Beta => () => Results.Failure.Beta;
            public static Func<Types.Beta, Result<Types.Alpha>> AlphaWithBetaParam => _ => Results.Failure.Alpha;
            public static Func<Types.Alpha, Result<Types.Beta>> BetaWithAlphaParam => _ => Results.Failure.Beta;
            public static Func<Types.Alpha, Result> VoidWithAlphaParam => _ => Results.Failure.Nothing;
        }

        public static class WithTask
        {
            public static Func<Task<Result>> Void => () => Task.FromResult(Results.Failure.Nothing);
            public static Func<Task<Result<Types.Alpha>>> Alpha => () => Task.FromResult(Results.Failure.Alpha);
            public static Func<Task<Result<Types.Beta>>> Beta => () => Task.FromResult(Results.Failure.Beta);
            public static Func<Types.Beta, Task<Result<Types.Alpha>>> AlphaWithBetaParam => _ => Task.FromResult(Results.Failure.Alpha);
            public static Func<Types.Alpha, Task<Result>> VoidWithAlphaParam => _ => Task.FromResult(Results.Failure.Nothing);
        }

        public static class WithValueTask
        {
            public static Func<ValueTask<Result>> Void => () => ValueTask.FromResult(Results.Failure.Nothing);
            public static Func<ValueTask<Result<Types.Alpha>>> Alpha => () => ValueTask.FromResult(Results.Failure.Alpha);
            public static Func<ValueTask<Result<Types.Beta>>> Beta => () => ValueTask.FromResult(Results.Failure.Beta);
            public static Func<Types.Beta, ValueTask<Result<Types.Alpha>>> AlphaWithBetaParam => _ => ValueTask.FromResult(Results.Failure.Alpha);
            public static Func<Types.Alpha, ValueTask<Result>> VoidWithAlphaParam => _ => ValueTask.FromResult(Results.Failure.Nothing);
        }
    }
}