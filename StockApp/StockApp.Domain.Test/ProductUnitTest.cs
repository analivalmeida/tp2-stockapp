using FluentAssertions;
using StockApp.Domain.Entities;
using System.Diagnostics;
using System.Xml.Linq;
using StockApp.Domain.Entities;
namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {

        #region Testes positivos

        [Fact(DisplayName = "Create Product with Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product().ValidateDomain(1, "Product Name", "Product Description", "Product url", 25, 3);
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion


        #region Testes negativos

        [Fact(DisplayName = "Create Product with Invalid Id")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Product().ValidateDomain(-1, "Product Name", "Product Description", "Product url", 25, 3);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }


        [Fact(DisplayName = "Create Product with Invalid Name")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product().ValidateDomain(1, null, "Product Description", "Product url", 25, 3);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }


        [Fact(DisplayName = "Create Product with Invalid Quantity")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidQuantity()
        {
            Action action = () => new Product().ValidateDomain(1, "Product Name", "Product Description", "Product url", 25, -3);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid quantity negative value.");
        }

        [Fact(DisplayName = "Create Product with Invalid Description")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product().ValidateDomain(1, "Product Name", "Prod", "Product url", 25, 3);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }


        [Fact(DisplayName = "Create Product with Invalid Price")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product().ValidateDomain(1, "Product Name", "Product Description", "Product url", -25, 3);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }


        [Fact(DisplayName = "Create Product with Invalid Image URL")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidUrlImage()
        {
            Action action = () => new Product().ValidateDomain(1, "Product Name", "Product Description", "https://t.ctcdn.com.br/Pp8AcSBhklh28T5N1v1HYG5esJ4=/768x432/smart/i257652.jpeg", 25, 3);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image url, too long, maximum 70 characters.");
        }

        #endregion

    }
}
