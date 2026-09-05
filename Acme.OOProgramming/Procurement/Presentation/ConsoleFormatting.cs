using Acme.OOProgramming.Procurement.Domain.Model.Aggregates;

namespace Acme.OOProgramming.Procurement.Presentation;

internal static class ConsoleFormatting
{
    extension(PurchaseOrder order)
    {
        public string Summary => $"Purchase Order {order.OrderNumber} created for Supplier ID {order.SupplierId.Identifier} in {order.Currency} on {order.OrderDate}";
    }
}
