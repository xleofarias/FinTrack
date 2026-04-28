using FinTrack.Application.Categories;
using FinTrack.Application.Categories.Commands.UpdateNameCategoryCommand;
using FinTrack.Domain.Entities;
using Moq;

namespace FinTrack.UnitTests.Application.Commands.UpdateCategory
{
    public class UpdateCategoryNameCommandTest
    {
        private readonly Mock<ICategoryRepository> _repo;
        private readonly UpdateNameCategoryCommandHandler _handler;

        public UpdateCategoryNameCommandTest()
        {
            _repo = new Mock<ICategoryRepository>();
            _handler = new UpdateNameCategoryCommandHandler(_repo.Object);
        }

        public async Task Update_ShouldReturns_WhenNameIsValid() 
        {
            //Arrange
            var category = Category.Create("Ativo", FinTrack.Domain.Enums.TransactionType.Income, "green");
            var newName = "Passivo";
            CancellationToken ct = default;

            _repo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(category);
            _repo.Setup(r => r.UpdateAsync(It.IsAny<Category>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            //Act
            var command = new UpdateNameCategoryCommand(category.Id, newName);

            await _handler.Handle(command, ct);
            
            //Assert
            _repo.Verify(v => v.UpdateAsync(It.Is<Category>(t => t.Name == newName), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}