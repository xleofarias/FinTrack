using FinTrack.Domain.Exceptions;
using FinTrack.Domain.ValueObjects;
using FluentAssertions;

namespace FinTrack.UnitTests.Domain.ValueObjects
{
    public class MoneyTests
    {
        [Fact]
        public void Create_ShouldReturnMoney_WhenAmountIsValid()
        {
            //Arrange - Preparação dos dados
            decimal amount = 100;
            string currency = "BRL";

            //Act - Ação
            var money = Money.Create(amount, currency);

            //Assert - verifica se o resultado é o esperado
            money.Amount.Should().Be(amount);
            money.Currency.Should().Be(currency);
        }

        [Fact]
        public void Create_ShouldThrow_WhenAmountIsZero()
        {
            //Arrange - Preparação de dados
            decimal amount = 0;
            string currency = "BRL";

            //Act - Ação
            Action act = () => Money.Create(amount, currency);

            //Assert - verifica se o resultado é o esperado
            act.Should().Throw<DomainException>().WithMessage("Amount must be greater than zero.");
        }

        [Fact]
        public void Create_ShouldThrow_WhenCurrencyIsEmpty()
        {
            //Arrange - Preparação de dados
            decimal amount = 100;
            string currency = string.Empty;

            //Act - Ação & Asset - verifica se o resultado é o esperado
            Action act = () => Money.Create(amount, currency);

            act.Should().Throw<DomainException>().WithMessage("Currency cannot be empty."); ;
        }

        [Fact]
        public void Create_ShouldUseDefaultCurrency_WhenCurrencyIsNotProvided()
        {
            //Arrange - Preparação de dados
            decimal amount = 100;

            //Act - Ação
            Money money = Money.Create(amount);

            //Asset - verifica se o resultado é o esperado
            money.Currency.Should().Be(Money.DefaultCurrency);
        }

        [Fact]
        public void Add_ShouldAddMoney_WhenCurrencyIsEquals()
        {
            // Arrange
            var money1 = Money.Create(100, "BRL");
            var money2 = Money.Create(150, "BRL");

            // Act
            var result = money1.Add(money2);

            // Assert
            result.Amount.Should().Be(money1.Amount + money2.Amount);
            result.Currency.Should().Be(money1.Currency);
        }

        [Fact]
        public void Add_ShouldThrow_WhenCurrencyDifferents()
        {
            // Arrange
            var moneyBRL = Money.Create(50, "BRL");
            var moneyUSD = Money.Create(100, "USD");

            // Act
            Action act = () => moneyBRL.Add(moneyUSD);

            // Assert
            act.Should().Throw<DomainException>().WithMessage($"Cannot operate on different currencies: {moneyBRL.Currency} and {moneyUSD.Currency}.");
        }

        [Fact]
        public void Subtract_ShouldSubtract_WhenCurrencyIsEquals()
        {
            // Arrange
            var money1 = Money.Create(250, "BRL");
            var money2 = Money.Create(150, "BRL");

            // Act
            var result = money1.Subtract(money2);

            // Assert
            result.Amount.Should().Be(money1.Amount - money2.Amount);
            result.Currency.Should().Be(money1.Currency);
        }

        [Fact]
        public void Subtract_ShouldThrow_WhenCurrencyDifferents()
        {
            // Arrange
            var moneyBRL = Money.Create(150, "BRL");
            var moneyUSD = Money.Create(100, "USD");

            // Act
            Action act = () => moneyBRL.Subtract(moneyUSD);

            // Assert
            act.Should().Throw<DomainException>().WithMessage($"Cannot operate on different currencies: {moneyBRL.Currency} and {moneyUSD.Currency}.");
        }

        [Fact]
        public void Subtract_ShouldThrow_WhenAmountExceeds()
        {
            // Arrange
            var money1 = Money.Create(150, "BRL");
            var money2 = Money.Create(350, "BRL");

            // Act
            Action act = () => money1.Subtract(money2);

            // Assert
            act.Should().Throw<DomainException>().WithMessage("Subtraction would result in a negative amount.");
        }
    }
}