using ImportProductsApp.Services.Contracts;
using ImportProductsApp.Services.Implementations;
using Moq;
using NUnit.Framework;
using AutoFixture;
using FluentAssertions;
using ImportProductsApp.Models;
using ImportProductsTests.Helpers;

namespace ImportProductsTests.UnitTests
{
    public class TestForSoftwareAdviceService
    {
        private IProductService _sut;
        private Mock<IFileService> _fileServiceMock;
        private Mock<ILogs> _logsMock;
        private Fixture _fixture;
        private string _sourcePath = "C:/Users/user/test.xml";

        [SetUp]
        public void SetUp()
        {
            _fileServiceMock = new Mock<IFileService>();
            _logsMock = new Mock<ILogs>();
            _fixture = new Fixture();
        }

        [Test]
        public void GetProducts_WhenCalled_ThenReturnProducts()
        {
            // Arrange
            _fileServiceMock
                .Setup(x => x.Exists(It.IsAny<string>()))
                .Returns(true);

            _fileServiceMock
                .Setup(x => x.ReadAllText(It.IsAny<string>()))
                .Returns(TestHelpers.ReadFile("softwareadvice.json"));

            _sut = new SoftwareAdviceService(_logsMock.Object, _fileServiceMock.Object);

            // Act
            var products = _sut.GetProducts(_sourcePath);

            // Assert
            products.Should().NotBeNull();
            products.Should().BeEquivalentTo(new List<Product>()
            {
                new Product()
                {
                    Categories = new List<string>() { "Customer Service", "Call Center" },
                    Name = "Freshdesk",
                    Twitter = "@freshdesk"
                },
                new Product()
                {
                    Categories = new List<string>() { "CRM", "Sales Management" },
                    Name = "Zoho"
                }
            });
        }

        [Test]
        public void GetProducts_WhenFileNotExist_ThenThrowException()
        {
            // Arrange
            _fileServiceMock
                .Setup(x => x.Exists(It.IsAny<string>()))
                .Returns(false);

            _sut = new SoftwareAdviceService(_logsMock.Object, _fileServiceMock.Object);

            // Act
            var act = new Func<List<Product>>(() => _sut.GetProducts(_sourcePath));

            // Assert 
            act.Should().Throw<ArgumentException>();
        }
    }
}
