using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer;

public readonly partial struct Result<TValue> : IResult
{
    private readonly List<ErrorMessage> _errors = new();
    private readonly List<WarningMessage> _warnings = new();
    private readonly TValue? _value = default;

    public Result()
    {
        IsFailure = true;
        _errors.Add(new ErrorMessage("Uninitialized result", "Result was created without a value"));
    }
    
    private Result(TValue value)
    {
        _value = value;
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
    public TValue Value => IsFailure ? throw new FailureResultException(_errors) : _value!;

    public IReadOnlyCollection<ErrorMessage> Errors => _errors.AsReadOnly();
    public IReadOnlyCollection<WarningMessage> Warnings => _warnings.AsReadOnly();
    
    internal Result<TValue> WithoutWarnings(IEnumerable<WarningMessage> warnings)
    {
        foreach (var warning in warnings)
        {
            _warnings.Remove(warning);
        }
        
        return this;
    }

    internal Result<TValue> WithWarning(WarningMessage warning)
    {
        _warnings.Add(warning);
        return this;
    }
    
    internal Result<TValue> WithWarnings(IEnumerable<WarningMessage> warnings)
    {
        _warnings.AddRange(warnings);
        return this;
    }
    
    public static implicit operator Result(Result<TValue> x) => new(x);
}