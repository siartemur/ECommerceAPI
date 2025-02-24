using MediatR;

namespace ECommerceAPI.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
