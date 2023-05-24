namespace Funcer.Tests.Common;

public static class Results
{
    public static class Success
    {
        public static Result Nothing => Result.Success();
        public static Result<Types.Alpha> Alpha1 => Result.Success(Values.Alpha1);
        public static Result<Types.Alpha> Alpha2 => Result.Success(Values.Alpha2);
        public static Result<Types.Beta> Beta1 => Result.Success(Values.Beta1);
        public static Result<Types.Beta> Beta2 => Result.Success(Values.Beta2);
        public static Result<Types.Beta> Beta3 => Result.Success(Values.Beta3);
    }
    
    public static class Failure
    {
        public static Result Nothing => Result.Failure(Values.TestError);
        public static Result<Types.Alpha> Alpha => Result.Failure<Types.Alpha>(Values.TestError);
        public static Result<Types.Beta> Beta => Result.Failure<Types.Beta>(Values.TestError);
    }
}