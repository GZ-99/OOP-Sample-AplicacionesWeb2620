namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

public record Currency
{
    public string Code { get; set; }

    public Currency(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentNullException("Code cannot be null or empty", nameof(code));
        
        Code = code;
        
    }
    
}
