using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.Product;
using APIMarketList.Domain.Interface.Services;

namespace APIMarketList.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductApplication _productApplication;
        public ProductService(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }
        
        public async Task<IList<ProductDTO>> Get() => await _productApplication.GetProductsAsync();
        public async Task<ProductDTO?> Get(long id) => await _productApplication.GetById(id);
        public async Task<ProductSaveResponseDTO> SaveOrUpdate(ProductSaveDTO productSave) => await _productApplication.SaveOrUpdate(productSave);
    }
}
