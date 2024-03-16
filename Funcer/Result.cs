using Funcer.Messages;

namespace Funcer;

public readonly partial struct Result : IResult
{
    private readonly List<ErrorMessage> _errors = new();
    private readonly List<WarningMessage> _warnings = new();

    public Result() { }
    
    internal Result(IResult result)
    {
        IsFailure = result.IsFailure;
        _errors.AddRange(result.Errors);
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

    public bool IsFailure { get; } = false;
    public bool IsSuccess => !IsFailure;

    public IReadOnlyCollection<ErrorMessage> Errors => _errors.AsReadOnly();
    public IReadOnlyCollection<WarningMessage> Warnings => _warnings.AsReadOnly();
    
    internal Result WithoutWarnings(IEnumerable<WarningMessage> warnings)
    {
        foreach (var warning in warnings)
        {
            _warnings.Remove(warning);
        }
        
        return this;
    }

    internal Result WithWarning(WarningMessage warning)
    {
        _warnings.Add(warning);
        return this;
    }

    internal Result WithWarnings(IEnumerable<WarningMessage> warnings)
    {
        _warnings.AddRange(warnings);
        return this;
    }
}