using Funcer.Messages;

namespace Funcer;

public partial struct Result<TValue> : IResult
{
    private readonly List<ErrorMessage> _errors = new();
    private readonly List<WarningMessage> _warnings = new();

    [Obsolete("Don't use the default constructor directly")]
    public Result()
    {
        Value = default;
    }
    
    private Result(TValue value)
    {
        Value = value;
    }

    private Result(ErrorMessage error)
    {
        IsFailure = true;
        _errors.Add(error);
    }
    
    private Result(IEnumerable<ErrorMessage> errors)
    {
        IsFailure = true;
        _errors = errors.ToList();
    }

    public bool IsFailure { get; }
    public bool IsSuccess => !IsFailure;
    public TValue? Value { get; }

    public IReadOnlyCollection<ErrorMessage> Errors => _errors.AsReadOnly();
    public IReadOnlyCollection<WarningMessage> Warnings => _warnings.AsReadOnly();
    
    internal void AddWarning(WarningMessage warning)
    {
        _warnings.Add(warning);
    }
    
    internal void AddWarnings(IEnumerable<WarningMessage> warnings)
    {
        _warnings.AddRange(warnings);
    }
    
    internal void RemoveWarning(WarningMessage warning)
    {
        _warnings.Remove(warning);
    }

    internal Result<TValue> WithWarning(WarningMessage warning)
    {
        AddWarning(warning);
        return this;
    }
    
    internal Result<TValue> WithWarnings(IEnumerable<WarningMessage> warnings)
    {
        AddWarnings(warnings);
        return this;
    }
}