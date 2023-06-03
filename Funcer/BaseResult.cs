using Funcer.Messages;

namespace Funcer;

public abstract class BaseResult
{
    private readonly List<Error> _errors = new();
    private readonly List<Warning> _warnings = new();
    
    protected BaseResult() { }

    protected BaseResult(Error error)
    {
        IsFailure = true;
        _errors.Add(error);
    }
    
    protected BaseResult(IEnumerable<Error> errors)
    {
        IsFailure = true;
        _errors = errors.ToList();
    }

    public bool IsFailure { get; }
    public bool IsSuccess => !IsFailure;

    public IReadOnlyCollection<Error> Errors => _errors.AsReadOnly();
    public IReadOnlyCollection<Warning> Warnings => _warnings.AsReadOnly();
    
    internal void AddWarning(Warning warning)
    {
        _warnings.Add(warning);
    }
    
    internal void AddWarnings(IEnumerable<Warning> warnings)
    {
        _warnings.AddRange(warnings);
    }
    
    internal void RemoveWarning(Warning warning)
    {
        _warnings.Remove(warning);
    }
}