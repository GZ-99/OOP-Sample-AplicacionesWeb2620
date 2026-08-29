namespace Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;

public record ProductId
{
    public Guid Id { get; init; }

    public ProductId(Guid id)
    {
        if (id == Guid.Empty) 
            throw new ArgumentException("Supplier id cannot be empty", nameof(id));
        
        Id = id;
        
    }
    
    public static ProductId New() => new ProductId(Guid.NewGuid());
    
    public override string ToString() => Id.ToString();
    
}
