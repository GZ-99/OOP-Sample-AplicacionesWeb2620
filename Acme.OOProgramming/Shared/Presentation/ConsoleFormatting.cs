using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

namespace Acme.OOProgramming.Shared.Presentation;

/// <summary>
/// Provides console formatting methods for value objects. 
/// </summary>
public static class ConsoleFormatting
{
    extension(Money money)
    {
        public string Display => $"{money.Amount:N2} {money.Currency.Code}";
    }
}
