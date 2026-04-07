using FinTrack.Domain.Entities;
using FinTrack.Domain.Enums;
using FinTrack.Domain.Exceptions;
using FluentAssertions;

namespace FinTrack.UnitTests.Domain.Entities
{
    public class CategoryTests
    {
        [Fact]
        public void Create_ShouldReturnsCategory_WhenCategoryIsValid()
        {
            // Arrange
            string name = "Luz";
            TransactionType transactionType = TransactionType.Expense;
            string color = "blue";

            // Act
            var category = Category.Create(name, transactionType, color);

            // Assert
            category.Name.Should().Be(name);
            category.Type.Should().Be(transactionType);
            category.Color.Should().Be(color);
        }

        [Fact]
        public void Create_ShouldThrow_WhenNameIsEmpty()
        {
            // Arrange
            string name = string.Empty;
            TransactionType transactionType = TransactionType.Expense;
            string color = "blue";

            // Act
            Action act = () => Category.Create(name, transactionType, color);

            // Assert
            act.Should().Throw<DomainException>().WithMessage("Category name cannot be empty.");
        }


        [Fact]
        public void Create_ShouldThrow_WhenTransactionTypeIsEmpty()
        {
            // Arrange
            string name = "Luz";
            TransactionType transactionType = (TransactionType)999;
            string color = "blue";

            //Act
            Action act = () => Category.Create(name, transactionType, color);

            //Assert
            act.Should().Throw<DomainException>().WithMessage("Invalid transaction type.");
        }

        [Fact]
        public void Create_ShouldThrow_WhenColorIsEmpty()
        {
            // Arrange
            string name = "Luz";
            TransactionType transactionType = TransactionType.Expense;
            string color = string.Empty;

            //Act
            Action act = () => Category.Create(name, transactionType, color);

            //Assert
            act.Should().Throw<DomainException>().WithMessage("Category color cannot be empty.");
        }

        [Fact]
        public void UpdateName_ShouldUpdateName_WhenNameIsValid()
        {
            // Arrange
            string name1 = "Luz";
            string name2 = "Agua";
            TransactionType transactionType = TransactionType.Expense;
            string color = "blue";

            // Act
            var category = Category.Create(name1, transactionType, color);
            category.UpdateName(name2);

            // Assert
            category.Name.Should().Be(name2);
            category.Type.Should().Be(transactionType);
            category.Color.Should().Be(color);
        }

        [Fact]
        public void UpdateName_ShouldThrow_WhenNameIsEmpty()
        {
            // Arrange
            string name1 = "Luz";
            string name2 = string.Empty;
            TransactionType transactionType = TransactionType.Expense;
            string color = "blue";

            // Act
            var category = Category.Create(name1, transactionType, color);
            Action act = () => category.UpdateName(name2);

            // Assert
            act.Should().Throw<DomainException>().WithMessage("Category name cannot be empty.");
        }

        [Fact]
        public void UpdateColor_ShouldUpdateColor_WhenColorIsValid()
        {            
            // Arrange
            string name = "Luz";
            TransactionType transactionType = TransactionType.Expense;
            string color1 = "blue";
            string color2 = "red";

            // Act
            var category = Category.Create(name, transactionType, color1);
            category.UpdateColor(color2);

            // Assert
            category.Name.Should().Be(name);
            category.Type.Should().Be(transactionType);
            category.Color.Should().Be(color2);
        }

        [Fact]
        public void UpdateColor_ShouldThrow_WhenColorIsEmpty()
        {
            // Arrange
            string name = "Luz";
            TransactionType transactionType = TransactionType.Expense;
            string color1 = "blue";
            string color2 = string.Empty;

            // Act
            var category = Category.Create(name, transactionType, color1);
            Action act = () => category.UpdateColor(color2);

            // Assert
            act.Should().Throw<DomainException>().WithMessage("Category color cannot be empty.");
        }
    }
}
