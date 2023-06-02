using Funcer.Messages;

namespace Funcer;

public partial class Result : BaseResult
{
    private Result() { }

    private Result(Error error) : base(error) { }
    
    private Result(IEnumerable<Error> errors) : base(errors) { }
    
    internal Result WithWarning(Warning warning)
    {
        AddWarning(warning);
        return this;
    }

    internal Result WithWarnings(IEnumerable<Warning> warnings)
    {
        AddWarnings(warnings);
        return this;
    }
}