using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Services;
using System.Transactions;

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
    }
}
