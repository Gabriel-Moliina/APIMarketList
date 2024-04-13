using APIMarketList.Application.Interface;
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
        
        public Task<IList<Product>> Get()
        {
            using var transaction = new TransactionScope();
            var response = _productApplication.get
        }
        public Product Get(int id)
        {

        }
    }
}
