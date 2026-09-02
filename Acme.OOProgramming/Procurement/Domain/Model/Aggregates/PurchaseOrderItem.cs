using Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;
using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

namespace Acme.OOProgramming.Procurement.Domain.Model.Aggregates;

public class PurchaseOrderItem
{
    public ProductId ProductId { get; }

    public int Quantity
    {
        get;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            field = value;
        }
    }

    public Money UnitPrice { get; }

    internal PurchaseOrderItem (ProductId productId, int quantity, Money unitPrice)
    {
        if (productId == default)
            throw new ArgumentException("Product ID is required.", nameof(productId));
        if (unitPrice == default)
            throw new ArgumentException("Unit Price is required.", nameof(unitPrice));
        
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    internal void IncreaseQuantity(int additionalQuantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(additionalQuantity);
        Quantity += additionalQuantity;
    }
    
    public Money CalculateItemTotal() => UnitPrice * Quantity;
}
