using FinTrack.Application.Transactions;
using FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateAmount;
using FinTrack.Domain.Entities;
using FinTrack.Domain.ValueObjects;
using Moq;
namespace FinTrack.UnitTests.Application.Commands.UpdateTransaction
{
    public class UpdateTransactionAmountCommandTest
    {
        private readonly Mock<ITransactionRepository> _repo;
        private readonly UpdateTransactionAmountCommandHandler _handler;

        public UpdateTransactionAmountCommandTest()
        {
            _repo = new Mock<ITransactionRepository>();
            _handler = new UpdateTransactionAmountCommandHandler(_repo.Object);
        }

        [Fact]
        public async Task Update_ShouldReturns_WhenAmountIsValid() 
        {
            //Arrange
            var money = Money.Create(100, "BRL");
            var category = Category.Create("Ativo", FinTrack.Domain.Enums.TransactionType.Income, "green");
            var transaction = Transaction.Create(money, "Cripto", DateTime.UtcNow, FinTrack.Domain.Enums.TransactionType.Income, category.Id);
            var newMoney = Money.Create(250, "BRL");
            CancellationToken ct = default;

            _repo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(transaction);
            _repo.Setup(r => r.UpdateAsync(It.IsAny<Transaction>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            //Act
            var command = new UpdateTransactionAmountCommand(transaction.Id, newMoney);

            await _handler.Handle(command, ct);
            //Assert
            _repo.Verify(v => v.UpdateAsync(
                It.Is<Transaction>(t => t.Amount == newMoney), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
