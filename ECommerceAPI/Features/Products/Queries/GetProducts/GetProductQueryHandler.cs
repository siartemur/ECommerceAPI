using MediatR;
using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Data;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, IEnumerable<Product>>

    {
        private readonly ApplicationDbContext _context;

        public GetProductsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.IncludeDeleted)
                return await _context.Products.IgnoreQueryFilters().ToListAsync(); // ✅ Tüm ürünleri getir

            return await _context.Products.ToListAsync(); // ✅ Varsayılan olarak silinmiş ürünleri filtrele
        }

    }
}
