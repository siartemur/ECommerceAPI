using AutoMapper;
using ECommerceAPI.Entities;
using ECommerceAPI.Features.Products.Commands.UpdateProduct;
using ECommerceAPI.Features.Products.Commands.CreateProduct;
using ECommerceAPI.Features.Products.Queries.GetProductById;

namespace ECommerceAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Command ve Query Response'ları Product'a mapliyoruz
            CreateMap<CreateProductCommandResponse, Product>();
            CreateMap<GetProductByIdQueryResponse, Product>();
            CreateMap<UpdateProductCommandResponse, Product>();
        }
    }
}
