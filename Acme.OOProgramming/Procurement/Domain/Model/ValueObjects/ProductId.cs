namespace Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;

/// <summary>
/// Represents a product identifier value object in the Procurement bounded context. 
/// </summary>
public readonly record struct ProductId
{
    public Guid Id
    {
        get;
        init
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Product ID cannot be an empty GUID.", nameof(value));
            field = value;
        }
    }
    
    public ProductId() => throw new InvalidOperationException("ProductId must be initialized with a non-empty GUID.");
    
    public ProductId(Guid id) => Id = id;
    
    public static ProductId New() => new(Guid.CreateVersion7());
    
    public override string ToString() => Id.ToString();
}
