using StockApp.Domain.Validation;

namespace StockApp.Domain.Entities
{
    public class Product
    {
        #region Atributos
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set;}
        public string Image { get; set; }
        public int CategoryId { get; set; }
        #endregion
        #region Construtores
        public Product(int id, string name, string description, string urlImage, decimal price, int quantity)
        {
            ValidateDomain(id, name, description, urlImage, price, quantity);
        }
        #endregion

        public Category Category { get; set; }

        private void ValidateDomain(int id, string name, string description, string urlImage, decimal price, int quantity)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description, name is required.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(urlImage.Length > 50, "Invalid image url, too long, maximum 50 characters.");

            DomainExceptionValidation.When(price < 0, "Invalid price negative value.");

            DomainExceptionValidation.When(quantity < 0, "Invalid quantity negative value.");
        }
    }
}