namespace Funcer.Tests.Common;

using Result = Funcer.Result;

public static class TestFunc
{
    public static class Returns
    {
        public static Action Void => () => { };
        public static Func<Types.Alpha> Alpha1 => () => TestValues.Alpha1;
        public static Func<Types.Beta> Beta1 => () => TestValues.Beta1;
        public static class Success
        {
            public static Func<Result> Empty => () => TestResult.Success;
            public static Func<Result<Types.Alpha>> Alpha1 => () => TestResult.Alpha.Success.V1;
            public static Func<Result<Types.Beta>> Beta1 => () => TestResult.Beta.Success.V1;
        }
        public static class Failure
        {
            public static Func<Result> Empty => () => TestResult.Failure;
            public static Func<Result<Types.Alpha>> Alpha => () => TestResult.Alpha.Failure;
            public static Func<Result<Types.Beta>> Beta => () => TestResult.Beta.Failure;
        }
        public static Func<bool> True => () => true;
        public static Func<bool> False => () => false;
        public static Func<Result<bool>> BoolSuccessTrue => () => TestResult.Bool.SuccessTrue;
        public static Func<Result<bool>> BoolSuccessFalse => () => TestResult.Bool.SuccessFalse;
        public static Func<Result<bool>> BoolFailure => () => TestResult.Bool.Failure;
    }
    
    public static class Takes
    {
        public static class Alpha
        {
            public static class Returns
            {
                public static Action<Types.Alpha> Nothing => _ => { };
                public static Func<Types.Alpha, Types.Alpha> Alpha1 => _ => TestValues.Alpha1;
                public static Func<Types.Alpha, Types.Beta> Beta1 => _ => TestValues.Beta1;
                public static class Success
                {
                    public static Func<Types.Alpha, Result> Empty => _ => TestResult.Success;
                    public static Func<Types.Alpha, Result<Types.Beta>> Beta1 => _ => TestResult.Beta.Success.V1;
                }
                public static class Failure
                {
                    public static Func<Types.Alpha, Result> Empty => _ => TestResult.Failure;
                    public static Func<Types.Alpha, Result<Types.Beta>> Beta => _ => TestResult.Beta.Failure;
                }
                public static Func<Types.Alpha, bool> IsFalse => x => x.Value is false;
                public static Func<Types.Alpha, bool> IsTrue => x => x.Value;
                public static Func<Types.Alpha, Result<bool>> BoolSuccessTrue => _ => TestResult.Bool.SuccessTrue;
                public static Func<Types.Alpha, Result<bool>> BoolSuccessFalse => _ => TestResult.Bool.SuccessFalse;
                public static Func<Types.Alpha, Result<bool>> BoolFailure => _ => TestResult.Bool.Failure;
            }
        }
        
        public static class Beta
        {
            public static class Returns
            {
                public static Action<Types.Beta> Nothing => _ => { };
                public static Func<Types.Beta, Types.Alpha> Alpha1 => _ => TestValues.Alpha1;
                public static class Success
                {
                    public static Func<Types.Beta, Result<Types.Alpha>> Alpha1 => _ => TestResult.Alpha.Success.V1;
                }
                public static class Failure
                {
                    public static Func<Types.Beta, Result<Types.Alpha>> Alpha => _ => TestResult.Alpha.Failure;
                }
            }
        }
    }
}