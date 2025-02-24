using MediatR;
using ECommerceAPI.Data;

namespace ECommerceAPI.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                return null;

            product.Name = request.Name;
            product.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateProductCommandResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
