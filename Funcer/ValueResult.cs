using Funcer.Messages;

namespace Funcer;

public partial class Result<TValue> : BaseResult
{
    private Result(TValue value)
    {
        Value = value;
    }
    
    private Result(Error error) : base(error) { }

    private Result(IEnumerable<Error> errors) : base(errors) { }
    
    public TValue? Value { get; }
    
    internal Result<TValue> WithWarning(Warning warning)
    {
        AddWarning(warning);
        return this;
    }
    
    internal Result<TValue> WithWarnings(IEnumerable<Warning> warnings)
    {
        AddWarnings(warnings);
        return this;
    }
}