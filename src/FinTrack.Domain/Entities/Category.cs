using FinTrack.Domain.Enums;
using FinTrack.Domain.Exceptions;
using FinTrack.Domain.Primitives;

namespace FinTrack.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; }
    public TransactionType Type { get; private set; }
    public string Color { get; private set; }

    private Category(Guid id, string name, TransactionType type, string color)
        : base(id)
    {
        Name = name;
        Type = type;
        Color = color;
    }

    public static Category Create(string name, TransactionType type, string color)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Category name cannot be empty.");

        if (!Enum.IsDefined(type))
            throw new DomainException("Invalid transaction type.");

        if (string.IsNullOrWhiteSpace(color))
            throw new DomainException("Category color cannot be empty.");

        return new Category(Guid.NewGuid(), name.Trim(), type, color.Trim());
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Category name cannot be empty.");

        Name = name.Trim();
    }

    public void UpdateColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            throw new DomainException("Category color cannot be empty.");

        Color = color.Trim();
    }
}
