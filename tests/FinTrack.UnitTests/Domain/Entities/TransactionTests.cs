using FinTrack.Domain.Entities;
using FinTrack.Domain.Enums;
using FinTrack.Domain.Exceptions;
using FinTrack.Domain.ValueObjects;
using FluentAssertions;

namespace FinTrack.UnitTests.Domain.Entities
{
    public class TransactionTests
    {
        [Fact]
        public void Create_ShouldReturns_WhenTransactionIsValid()
        {
            //Arrange
            Money amount = Money.Create(100, "BRL");
            string description = "Pix da luz";
            DateTime date = DateTime.UtcNow;
            TransactionType type = TransactionType.Expense;
            Guid id = Guid.NewGuid();

            //Act
            var transaction = Transaction.Create(amount, description, date, type, id);

            //Assert
            transaction.Amount.Should().Be(amount);
            transaction.Description.Should().Be(description);
            transaction.Date.Should().Be(date);
            transaction.Type.Should().Be(type);
            transaction.CategoryId.Should().Be(id);
        }

        [Fact]
        public void Create_ShouldThrow_WhenDescriptionIsEmpty()
        {
            //Arrange
            Money amount = Money.Create(100, "BRL");
            string description = string.Empty;
            DateTime date = DateTime.UtcNow;
            TransactionType type = TransactionType.Expense;
            Guid id = Guid.NewGuid();

            //Act
            Action act = () => Transaction.Create(amount, description, date, type, id);

            //Assert
            act.Should().Throw<DomainException>().WithMessage("Transaction description cannot be empty.");
        }

        [Fact]
        public void Create_ShouldThrow_WhenDateIsInvalid()
        {
            //Arrange
            Money amount = Money.Create(100, "BRL");
            string description = "Pix da luz";
            DateTime date = DateTime.UtcNow.AddHours(1);
            TransactionType type = TransactionType.Expense;
            Guid id = Guid.NewGuid();

            //Act
            Action act = () => Transaction.Create(amount, description, date, type, id);

            //Assert
            act.Should().Throw<DomainException>().WithMessage("Transaction date cannot be in the future.");
        }

        [Fact]
        public void Create_ShouldThrow_WhenIdNotExisting()
        {
            //Arrange
            Money amount = Money.Create(100, "BRL");
            string description = "Pix da luz";
            DateTime date = DateTime.UtcNow;
            TransactionType type = TransactionType.Expense;
            Guid id = Guid.Empty;

            //Act
            Action act = () => Transaction.Create(amount, description, date, type, id);

            //Assert
            act.Should().Throw<DomainException>().WithMessage("Transaction must have a category.");
        }

        [Fact]
        public void Create_ShouldThrow_WhenTypeNotDefined()
        {
            //Arrange
            Money amount = Money.Create(100, "BRL");
            string description = "Pix da luz";
            DateTime date = DateTime.UtcNow;
            TransactionType type = (TransactionType)999;
            Guid id = Guid.NewGuid();

            //Act
            Action act = () => Transaction.Create(amount, description, date, type, id);

            //Assert
            act.Should().Throw<DomainException>().WithMessage("Invalid transaction type.");
        }

        [Fact]
        public void UpdateDescription_ShouldReturns_WhenDescriptionIsValid()
        {
            //Arrange
            Money amount = Money.Create(100, "BRL");
            string description = "Pix da luz";
            string newDescription = "Pix da água";
            DateTime date = DateTime.UtcNow;
            TransactionType type = TransactionType.Expense;
            Guid id = Guid.NewGuid();

            //Act
            var transaction = Transaction.Create(amount, description, date, type, id);
            transaction.UpdateDescription(newDescription);

            //Assert
            transaction.Description.Should().Be(newDescription);
        }

        [Fact]
        public void UpdateDescription_ShouldThrow_WhenDescriptionIsEmpty()
        {
            //Arrange
            Money amount = Money.Create(100, "BRL");
            string description = "Pix da luz";
            string newDescription = string.Empty;
            DateTime date = DateTime.UtcNow;
            TransactionType type = TransactionType.Expense;
            Guid id = Guid.NewGuid();

            //Act
            var transaction = Transaction.Create(amount, description, date, type, id);
            Action act = () => transaction.UpdateDescription(newDescription);

            //Assert
            act.Should().Throw<DomainException>().WithMessage("Transaction description cannot be empty.");
        }
    }
}
