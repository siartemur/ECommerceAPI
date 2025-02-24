using MediatR;
using ECommerceAPI.Data;
using ECommerceAPI.Entities;


// TODO: Single Responsiblity Principle

namespace ECommerceAPI.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                IsDeleted = false // ✅ Burada açıkça false olarak belirtiyoruz.
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateProductCommandResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

    }
}
