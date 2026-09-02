namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a currency value object.
/// </summary>
public readonly record struct Currency
{
    public string Code
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length != 3 || !value.All(char.IsAsciiLetter))
                throw new ArgumentException("Currency must be a valid 3-letter ISO 4217 alphabetic code.", nameof(Code));
            field = value.ToUpperInvariant();
        }
    }
    
    public Currency() => throw new InvalidOperationException("Currency must be initialized with a valid 3-letter ISO 4217 code.");
    
    public Currency(string code) => Code = code;
    
    public override string ToString() => Code;
}
