using MediatR;
using ECommerceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetProductByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Where(p => p.Id == request.Id)
                .Select(p => new GetProductByIdQueryResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .FirstOrDefaultAsync();

            return product;
        }
    }
}
