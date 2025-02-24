using MediatR;

namespace ECommerceAPI.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetProductByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
