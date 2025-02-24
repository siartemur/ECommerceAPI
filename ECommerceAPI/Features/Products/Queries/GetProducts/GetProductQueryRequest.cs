using ECommerceAPI.Entities;
using MediatR;

namespace ECommerceAPI.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryRequest : IRequest<IEnumerable<Product>>

    {
        public bool IncludeDeleted { get; set; } = false; 
    }
}
