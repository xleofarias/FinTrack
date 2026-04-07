using FinTrack.Domain.Exceptions;

namespace FinTrack.Domain.ValueObjects;

public sealed record Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public static readonly string DefaultCurrency = "BRL";

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Create(decimal amount, string? currency = null)
    {
        var resolvedCurrency = currency ?? DefaultCurrency;

        if (amount <= 0)
            throw new DomainException("Amount must be greater than zero.");

        if (string.IsNullOrWhiteSpace(resolvedCurrency))
            throw new DomainException("Currency cannot be empty.");

        return new Money(amount, resolvedCurrency.ToUpperInvariant());
    }

    public Money Add(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        EnsureSameCurrency(other);

        if (other.Amount > Amount)
            throw new DomainException("Subtraction would result in a negative amount.");

        return new Money(Amount - other.Amount, Currency);
    }

    private void EnsureSameCurrency(Money other)
    {
        if (Currency != other.Currency)
            throw new DomainException($"Cannot operate on different currencies: {Currency} and {other.Currency}.");
    }

    public override string ToString() => $"{Amount:F2} {Currency}";
}
