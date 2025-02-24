using MediatR;

namespace ECommerceAPI.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }

        public DeleteProductCommandRequest(int id)
        {
            Id = id;
        }
    }
}
