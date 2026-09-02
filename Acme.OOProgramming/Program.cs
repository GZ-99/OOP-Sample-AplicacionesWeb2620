// See https://aka.ms/new-console-template for more information

using Acme.OOProgramming.Procurement.Domain.Model.Aggregates;
using Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;
using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;
using Acme.OOProgramming.SupplyChain.Domain.Model.Aggregates;
using Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects;

Console.WriteLine("Hello, World!");

var supplierAddress = new Address("Main St", "123", "CA", null, "12345", "United States");

var supplier = new Supplier(new SupplierId("SUPPLIER-1"), "Acme Suppliers", supplierAddress);

var salesOfDay = new Money(1000, "USD");

var purchaseOrder = new PurchaseOrder("PO-01", supplier.Id, DateOnly.FromDateTime(DateTime.Now), new Currency("USD"));

var sharedProduct = ProductId.New();

purchaseOrder.AddItem(sharedProduct, 10, 25.99m);
purchaseOrder.AddItem(sharedProduct, 5, 25.99m);
purchaseOrder.AddItem(ProductId.New(), 20, 19.99m);

Console.WriteLine(purchaseOrder.CalculateTotal());
