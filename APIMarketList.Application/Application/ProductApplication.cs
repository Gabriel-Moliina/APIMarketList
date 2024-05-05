using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO;
using APIMarketList.Domain.Interface.Repositories;
using System.Transactions;

namespace APIMarketList.Application.Application
{
    public class ProductApplication : BaseApplication, IProductApplication
    {
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var response = await _productRepository.GetProductsAsync();
            transaction.Complete();
            return response;
        }
    }
}
