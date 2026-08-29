using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

namespace Acme.OOProgramming.SCM.Domain.Model.Aggregates;

public class Supplier(string identifier, string name, Address address)
{
    public string Identifier { get; }  = identifier ?? throw new ArgumentNullException(nameof(identifier));
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public Address Address { get; } = address ?? throw new ArgumentNullException(nameof(address));
}