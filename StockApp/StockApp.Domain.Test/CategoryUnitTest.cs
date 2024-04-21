using FluentAssertions;
using StockApp.Domain.Entities;

namespace StockApp.Domain.Test
{
    public class CategoryUnitTest
    {

        #region Testes positivos

        [Fact(DisplayName = "Create Category with Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion


        #region Testes negativos

        [Fact(DisplayName = "Create Category with Invalid State Id")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Category with Invalid State Name")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Category with Null State Name")]
        public void CreateCategory_WithNullParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        #endregion

    }
}
