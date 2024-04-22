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
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create product with valid state")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product(1, "Prada", "Bolsa Prada", 1000, 10, "prada.jpg");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with invalid state id")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInValidId()
        {
            Action action = () => new Product(-1, "Prada", "Bolsa Prada", 1000, 10, "prada.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with null name")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Bolsa Prada", 1000, 10, "prada.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with invalid name")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "bo", "Bolsa Prada", 1000, 10, "prada.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>();
        }


    }
}
