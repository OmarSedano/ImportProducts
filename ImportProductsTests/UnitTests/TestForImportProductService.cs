using AutoFixture;
using ImportProductsApp.Models;
using ImportProductsApp.Services.Contracts;
using ImportProductsApp.Services.Implementations;
using Moq;
using NUnit.Framework;

namespace ImportProductsTests.UnitTests
{
    public class TestForImportProductService
    {
        private IImportProductService _sut;
        private Mock<IProductsRepository> _productRepoMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<ILogs> _logsMock;
        private Func<string, IProductService> _productServiceFactory;
        private Fixture _fixture;
        private string _sourcePath = "C:/Users/user/capterratest.xml";
        private string _source = "capterratest";

        [SetUp]
        public void SetUp()
        {
            _productRepoMock = new Mock<IProductsRepository>();
            _logsMock = new Mock<ILogs>();
            _productServiceMock = new Mock<IProductService>();
            _fixture = new Fixture();

            _productServiceFactory = new Func<string, IProductService>((source) => _productServiceMock.Object);

        }
        [Test]
        public void ImportAsync_WhenCalled_ThenReadAndSaveProducts()
        {
            // Arrange
            _sut = new ImportProductService(_productRepoMock.Object, _productServiceFactory, _logsMock.Object);

            // Act
            _sut.ImportAsync(_source, _sourcePath);

            // Assert
            _productServiceMock
                .Verify(x => x.GetProducts(It.IsAny<string>()), Times.Once);

            _productRepoMock
                .Verify(x => x.SaveAsync(It.IsAny<List<Product>>()), Times.Once);
        }
    }
}
