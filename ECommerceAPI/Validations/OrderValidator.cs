using FluentValidation;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün ID'si giriniz.");

            RuleFor(o => o.Quantity)
                .GreaterThan(0).WithMessage("Sipariş miktarı en az 1 olmalıdır.");
        }
    }
}
