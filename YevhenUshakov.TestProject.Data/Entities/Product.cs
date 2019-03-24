using System;
using FluentValidation;
using YevhenUshakov.TestProject.Data.Enums;

namespace YevhenUshakov.TestProject.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductTypes ProductType { get; set; }
        public decimal Price { get; set; }
        public decimal Returns { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ProductType).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Returns).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        }
    }
}
