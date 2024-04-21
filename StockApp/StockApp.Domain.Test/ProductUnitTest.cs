using FluentAssertions;
using StockApp.Domain.Entities;
using System.Diagnostics;
using System.Xml.Linq;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {

        #region Testes positivos

        [Fact(DisplayName = "Create Product with Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product(1, "Boticário Lily", "Nacional", "https://image", 300, 10);
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion


        #region Testes negativos

        [Fact(DisplayName = "Create Product with Invalid Id")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Boticário Lily", "Nacional", "https://image", 300, 10);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product with Invalid Name")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "", "Nacional", "https://image", 300, 10);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product with Invalid Description")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Boticário Lily", "Nac", "https://image", 300, 10);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }


        [Fact(DisplayName = "Create Product with Invalid Image URL")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidUrlImage()
        {
            Action action = () => new Product(1, "Boticário Lily", "Nacional", "https://image.com/share/794f4873-6a6e-4d3d-a593-319e08efb1fa", 300, 10);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image url, too long, maximum 50 characters.");
        }


        [Fact(DisplayName = "Create Product with Invalid Price")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Boticário Lily", "Nacional", "https://image", -300, 10);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product with Invalid Quantity")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidQuantity()
        {
            Action action = () => new Product(1, "Boticário Lily", "Nacional", "https://image", 300, -10);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid quantity negative value.");
        }
        #endregion

    }
}
