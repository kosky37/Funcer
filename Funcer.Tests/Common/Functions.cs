namespace Funcer.Tests.Common;

public static class Functions
{
    public static class Returns
    {
        public static Action Nothing => () => { };
        public static Func<Types.Alpha> Alpha1 => () => Values.Alpha1;
        public static Func<Types.Beta> Beta1 => () => Values.Beta1;
        public static class Success
        {
            public static Func<Result> Empty => () => Results.Success.Nothing;
            public static Func<Result<Types.Alpha>> Alpha1 => () => Results.Success.Alpha1;
            public static Func<Result<Types.Beta>> Beta1 => () => Results.Success.Beta1;
        }
        public static class Failure
        {
            public static Func<Result> Empty => () => Results.Failure.Nothing;
            public static Func<Result<Types.Alpha>> Alpha => () => Results.Failure.Alpha;
            public static Func<Result<Types.Beta>> Beta => () => Results.Failure.Beta;
        }
        public static Func<bool> True => () => true;
        public static Func<bool> False => () => true;
    }
    
    public static class Takes
    {
        public static class Alpha
        {
            public static class Returns
            {
                public static Action<Types.Alpha> Nothing => _ => { };
                public static Func<Types.Alpha, Types.Alpha> Alpha1 => _ => Values.Alpha1;
                public static class Success
                {
                    public static Func<Types.Alpha, Result> Empty => _ => Results.Success.Nothing;
                    public static Func<Types.Alpha, Result<Types.Beta>> Beta1 => _ => Results.Success.Beta1;
                }
                public static class Failure
                {
                    public static Func<Types.Alpha, Result> Empty => _ => Results.Failure.Nothing;
                    public static Func<Types.Alpha, Result<Types.Beta>> Beta => _ => Results.Failure.Beta;
                }
                public static Func<Types.Alpha, bool> IsFalse => x => x.Value is false;
                public static Func<Types.Alpha, bool> IsTrue => x => x.Value;
            }
        }
        
        public static class Beta
        {
            public static class Returns
            {
                public static Action<Types.Beta> Nothing => _ => { };
                public static Func<Types.Beta, Types.Alpha> Alpha1 => _ => Values.Alpha1;
                public static class Success
                {
                    public static Func<Types.Beta, Result<Types.Alpha>> Alpha1 => _ => Results.Success.Alpha1;
                }
                public static class Failure
                {
                    public static Func<Types.Beta, Result<Types.Alpha>> Alpha => _ => Results.Failure.Alpha;
                }
            }
        }
    }
}