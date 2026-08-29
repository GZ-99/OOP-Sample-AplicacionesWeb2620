namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

public record Money
{
    public decimal Value { get; init; }
    public string Currency { get; init; }
    
    public Money (decimal value, string currency)
    {
        if (string.IsNullOrEmpty(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be a valid 3-letter ISO code", nameof(currency));
        
        Value = value;
        Currency = currency;
        
    }

    public override string ToString()  => $"{Value} {Currency}";
    
}
