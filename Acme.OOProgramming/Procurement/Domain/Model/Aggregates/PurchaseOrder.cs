using Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;
using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;
using Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects;

namespace Acme.OOProgramming.Procurement.Domain.Model.Aggregates;

public class PurchaseOrder
{
    private readonly List<PurchaseOrderItem> _items = [];
    private IReadOnlyList<PurchaseOrderItem>? _itemsView;
    
    public string OrderNumber { get; }
    
    public SupplierId SupplierId { get; }
    
    public DateOnly OrderDate { get; }
    
    public Currency Currency { get; }
    
    public IReadOnlyList<PurchaseOrderItem> Items => _itemsView ??= _items.AsReadOnly();

    public PurchaseOrder(string orderNumber, SupplierId supplierId, DateOnly orderDate, Currency currency)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(orderNumber);
        if (supplierId == default)
            throw new ArgumentException("Supplier ID is required.", nameof(supplierId));
        if  (orderDate == default)
            throw new ArgumentException("Order date is required.", nameof(orderDate));
        
        OrderNumber = orderNumber;
        SupplierId = supplierId;
        OrderDate = orderDate;
        Currency = currency;
    }

    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        if (productId == default)
            throw new ArgumentException("Product ID is required.", nameof(productId));
        
        var unitPrice = new Money(unitPriceAmount, Currency);
        var existing = _items.Find(item => item.ProductId == productId);

        if (existing is not null)
        {
            if (existing.UnitPrice != unitPrice)
                throw new InvalidOperationException($"Cannot add product '{productId}' at {unitPrice}; the order already has it at {existing.UnitPrice}.");
            
            existing.IncreaseQuantity(quantity);
            return;
        }
        
        _items.Add(new PurchaseOrderItem(productId, quantity, unitPrice));
    }

    public Money CalculateTotal()
    {
        var total = new Money(0, Currency);
        foreach (var item in _items) total += item.CalculateItemTotal();
        return total;
    }
}
