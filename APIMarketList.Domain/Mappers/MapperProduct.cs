using APIMarketList.Domain.DTO.Product;
using APIMarketList.Domain.Entities;
using AutoMapper;

namespace APIMarketList.Domain.Mappers
{
    public class MapperProduct : Profile
    {
        public MapperProduct()
        {
            CreateMap<ProductSaveDTO, Product>();
            CreateMap<Product, ProductSaveResponseDTO>();
        }
    }
}
