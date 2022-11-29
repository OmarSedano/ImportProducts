
using AutoFixture;
using FluentAssertions;
using ImportProductsApp.Mappers;
using ImportProductsApp.Models;
using NUnit.Framework;

namespace ImportProductsTests.UnitTests
{
    public class TestsForProductMapper
    {
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
        }

        #region Map ProductCapterra

        [Test]
        public void MapProductCapterra_WhenCalled_ThenReturnProductModel()
        {
            // Arrange
            var tags = "Category1,Category2,Category3";
            var productCapterra = _fixture
                .Build<ProductCapterra>()
                .With(p => p.Tags, tags)
                .Create();


            // Act
            var result = ProductMapper.Map(productCapterra);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(productCapterra.Name);
            result.Twitter.Should().Be($"@{productCapterra.Twitter}");
            result.Categories.Should().BeEquivalentTo(tags.Split(',').ToList());
        }

        [Test]
        public void MapProductCapterra_WhenTagsIsNull_ThenReturnProductModel()
        {
            // Arrange
            var productCapterra = _fixture
                .Build<ProductCapterra>()
                .With(p => p.Tags, value: null)
                .Create();


            // Act
            var result = ProductMapper.Map(productCapterra);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(productCapterra.Name);
            result.Twitter.Should().Be($"@{productCapterra.Twitter}");
            result.Categories.Should().BeEquivalentTo(Array.Empty<string>());
        }


        [Test]
        public void MapProductCapterra_WhenProductIsNull_ThenThrowException()
        {
            // Arrange
            // Act
            var act = new Func<Product>(() => ProductMapper.Map(productCapterra: null));

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        #endregion Map ProductCapterra

        #region Map ProductSoftwareAdvice

        [Test]
        public void MapProductSoftwareAdvice_WhenCalled_ThenReturnProductModel()
        {
            // Arrange
            var categories = new List<string>{"Category1","Category2","Category3"};
            var productSoftwareAdvice = _fixture
                .Build<ProductSoftwareAdvice>()
                .With(p => p.Categories, categories)
                .Create();


            // Act
            var result = ProductMapper.Map(productSoftwareAdvice);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(productSoftwareAdvice.Title);
            result.Twitter.Should().Be(productSoftwareAdvice.Twitter);
            result.Categories.Should().BeEquivalentTo(productSoftwareAdvice.Categories);
        }

        [Test]
        public void MapProductSoftwareAdvice_WhenTagsIsNull_ThenReturnProductModel()
        {
            // Arrange
            var productSoftwareAdvice = _fixture
                .Build<ProductSoftwareAdvice>()
                .With(p => p.Categories, value: null)
                .Create();


            // Act
            var result = ProductMapper.Map(productSoftwareAdvice);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(productSoftwareAdvice.Title);
            result.Twitter.Should().Be(productSoftwareAdvice.Twitter);
            result.Categories.Should().BeEquivalentTo(Array.Empty<string>());
        }

        [Test]
        public void MapProductSoftwareAdvice_WhenProductIsNull_ThenThrowException()
        {
            // Arrange
            // Act
            var act = new Func<Product>(() => ProductMapper.Map(productSoftAdvice: null));

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        #endregion Map ProductSoftwareAdvice

    }
}
