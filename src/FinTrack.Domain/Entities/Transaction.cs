using FinTrack.Domain.Enums;
using FinTrack.Domain.Exceptions;
using FinTrack.Domain.Primitives;
using FinTrack.Domain.ValueObjects;

namespace FinTrack.Domain.Entities;

public sealed class Transaction : Entity
{
    public Money Amount { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public TransactionType Type { get; private set; }
    public Guid CategoryId { get; private set; }

    private Transaction(
        Guid id,
        Money amount,
        string description,
        DateTime date,
        TransactionType type,
        Guid categoryId)
        : base(id)
    {
        Amount = amount;
        Description = description;
        Date = date;
        Type = type;
        CategoryId = categoryId;
    }

    public static Transaction Create(
        Money amount,
        string description,
        DateTime date,
        TransactionType type,
        Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Transaction description cannot be empty.");

        if (date > DateTime.UtcNow)
            throw new DomainException("Transaction date cannot be in the future.");

        if (categoryId == Guid.Empty)
            throw new DomainException("Transaction must have a category.");

        if (!Enum.IsDefined(type))
            throw new DomainException("Invalid transaction type.");

        return new Transaction(Guid.NewGuid(), amount, description.Trim(), date, type, categoryId);
    }

    public void UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Transaction description cannot be empty.");

        Description = description.Trim();
    }

    public void UpdateAmount(Money amount)
    {
        Amount = amount;
    }
}
