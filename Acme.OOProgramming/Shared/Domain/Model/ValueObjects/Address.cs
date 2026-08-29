namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents an international physical address value object.
/// 
/// </summary>
public record Address
{
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string? StateOrRegion { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    
    public Address(string street, string number, string city, 
        string? stateOrRegion, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentNullException("Street cannot be null or empty", nameof(street));
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentNullException("Number cannot be null or empty", nameof(number));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentNullException("City cannot be null or empty", nameof(city));
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentNullException("Postal code cannot be null or empty", nameof(postalCode));
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentNullException("Country cannot be null or empty", nameof(country));
        
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
        
    }
    
    public override string ToString() => $"{Street} {Number} {City} {StateOrRegion} {PostalCode} {Country}";
    
}
