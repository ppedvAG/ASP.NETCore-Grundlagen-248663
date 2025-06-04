using BusinessLogic.Tests;
using BusinessModel.Services;

namespace BusinessModel.Tests
{
    [TestClass]
    public sealed class RecipeServiceTests
    {
        // TODO alle CRUD Methoden abtesten
        // Sowohl Good als auch Bad Cases

        [TestMethod]
        public async Task GetAll_ShouldReturnAllAsync()
        {
            using (var context = new TestDatabase().Context)
            {
                // Arrange
                var sut = new RecipeService(context, null);

                // Act
                var result = await sut.GetAll();

                // Assert
                Assert.IsTrue(result.Any());
                // TODO weitere, sinnvolle Asserts
            }
        }
    }
}
