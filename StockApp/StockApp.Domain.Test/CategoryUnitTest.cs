using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using StockApp.Domain.Entities;
using Xunit;

namespace StockApp.Domain.Test
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "bolsas");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Invalid State Id")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInValidId()
        {
            Action action = () => new Category(-1, "");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create category with invalid state name")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "bo");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create category with null state name")]
        public void CreateCategory_WithNullParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
