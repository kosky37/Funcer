namespace Funcer.Tests.Common;

public static class Functions
{
    public static class Returns
    {
        public static Action Nothing => () => { };
        public static Func<Types.Alpha> Alpha1 => () => Values.Alpha1;
        public static Func<Types.Beta> Beta1 => () => Values.Beta1;
    }
    
    public static class Takes
    {
        public static class Alpha
        {
            public static class Returns
            {
                public static Action<Types.Alpha> Nothing => _ => { };
                public static Func<Types.Alpha, Types.Alpha> Alpha1 => _ => Values.Alpha1;
            }
        }
        
        public static class Beta
        {
            public static class Returns
            {
                public static Action<Types.Beta> Nothing => _ => { };
                public static Func<Types.Beta, Types.Alpha> Alpha1 => _ => Values.Alpha1;
            }
        }
    }
}