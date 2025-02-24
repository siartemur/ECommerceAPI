using MediatR;
using ECommerceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeleteProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (product == null)
                return new DeleteProductCommandResponse { IsSuccess = false, Message = "Ürün bulunamadı." };

            product.IsDeleted = true; // ✅ Soft Delete işlemi
            await _context.SaveChangesAsync();

            return new DeleteProductCommandResponse { IsSuccess = true, Message = "Ürün başarıyla silindi." };
        }
    }
}
