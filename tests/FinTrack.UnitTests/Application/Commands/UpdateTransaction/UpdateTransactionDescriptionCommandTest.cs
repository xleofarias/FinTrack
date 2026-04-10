using Moq;
using FinTrack.Application.Transactions.Commands.UpdateTransaction;
using FinTrack.Application.Transactions;

namespace FinTrack.UnitTests.Application.Commands.UpdateTransaction
{
    public class UpdateTransactionDescriptionCommandTest
    {
        private readonly Mock<UpdateTransactionDescriptionCommandHandler> _mockHandler;
        private readonly Mock<ITransactionRepository> _mockRepo;

        public UpdateTransactionDescriptionCommandTest()
        {
            _mockHandler = new Mock<UpdateTransactionDescriptionCommandHandler>();
            _mockRepo = new Mock<ITransactionRepository>();
        }

        [Fact]
        public void Update_ShouldReturns_WhenDescriptionIsValid()
        {
            //Arrange
            
        }
    }
}
