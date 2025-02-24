using FluentValidation;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(100).WithMessage("Ürün adı 100 karakterden fazla olamaz.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Ürün fiyatı sıfırdan büyük olmalıdır.");
        }
    }
}
