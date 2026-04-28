using Moq;
using FinTrack.Application.Transactions;
using FinTrack.Domain.Entities;
using FinTrack.Domain.ValueObjects;
using FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateDescription;

namespace FinTrack.UnitTests.Application.Commands.UpdateTransaction
{
    public class UpdateTransactionDescriptionCommandTest
    {
        private readonly UpdateTransactionDescriptionCommandHandler _handler;
        private readonly Mock<ITransactionRepository> _mockRepo;

        public UpdateTransactionDescriptionCommandTest()
        {
            _mockRepo = new Mock<ITransactionRepository>();
            _handler = new UpdateTransactionDescriptionCommandHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Update_ShouldReturns_WhenDescriptionIsValid()
        {
            // Arrange
            Money money = Money.Create(100, "BRL");
            Category category = Category.Create("Passiva",FinTrack.Domain.Enums.TransactionType.Expense, "green");
            Transaction transaction = Transaction.Create(money, "Conta de Água", DateTime.UtcNow, FinTrack.Domain.Enums.TransactionType.Expense, category.Id);
            var newDescription = "Conta de Luz";
            CancellationToken ct = default;

            _mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(transaction);
            _mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Transaction>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            
            // Act
            var command = new UpdateTransactionDescriptionCommand(transaction.Id, newDescription);

            await _handler.Handle(command, ct);

            // Assert
            _mockRepo.Verify(r => r.UpdateAsync(
                It.Is<Transaction>(t => t.Description == newDescription), 
                It.IsAny<CancellationToken>()),
                Times.Once
            );
        }
    }
}
