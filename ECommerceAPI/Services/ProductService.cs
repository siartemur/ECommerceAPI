using MediatR;
using AutoMapper;
using ECommerceAPI.Entities;
using ECommerceAPI.Services.Interfaces;
using FluentValidation;
using ECommerceAPI.Features.Products.Commands.CreateProduct;
using ECommerceAPI.Features.Products.Commands.DeleteProduct;
using ECommerceAPI.Features.Products.Commands.UpdateProduct;
using ECommerceAPI.Features.Products.Queries.GetProductById;
using ECommerceAPI.Features.Products.Queries.GetProducts;

namespace ECommerceAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IValidator<Product> _productValidator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IValidator<Product> productValidator, IMapper mapper)
        {
            _mediator = mediator;
            _productValidator = productValidator;
            _mapper = mapper;
        }

        /// <summary>
        /// Yeni ürün oluşturur.
        /// </summary>
        public async Task<Product> CreateProductAsync(CreateProductCommandRequest command)
        {
            await ValidateProduct(command);
            var response = await _mediator.Send(command);
            return _mapper.Map<Product>(response);
        }

        /// <summary>
        /// Tüm ürünleri getirir.
        /// </summary>
        public async Task<IEnumerable<Product>> GetProductsAsync(bool includeDeleted = false)
        {
            var response = await _mediator.Send(new GetProductsQueryRequest { IncludeDeleted = includeDeleted });
            return _mapper.Map<IEnumerable<Product>>(response);
        }

        /// <summary>
        /// Belirtilen ID'ye sahip ürünü getirir.
        /// </summary>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var response = await _mediator.Send(new GetProductByIdQueryRequest(id));
            return response != null ? _mapper.Map<Product>(response) : null;
        }

        /// <summary>
        /// Ürün günceller.
        /// </summary>
        public async Task<Product> UpdateProductAsync(UpdateProductCommandRequest command)
        {
            await ValidateProduct(command);
            var response = await _mediator.Send(command);
            return _mapper.Map<Product>(response);
        }

        private async Task ValidateProduct(UpdateProductCommandRequest command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ürün siler.
        /// </summary>
        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _mediator.Send(new DeleteProductCommandRequest(id));
            return response.IsSuccess;
        }

        /// <summary>
        /// Ürün validasyonlarını çalıştırır.
        /// </summary>
        private async Task ValidateProduct(CreateProductCommandRequest command)
        {
            var validationResult = _productValidator.Validate(new Product
            {
                Name = command.Name, 
                Price = command.Price
            });

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
        }

    }
}
