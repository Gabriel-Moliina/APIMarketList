using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.Product;
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
        
        public async Task<IList<ProductDTO>> Get() => await _productApplication.Get();
        public async Task<ProductDTO?> Get(long id) => await _productApplication.GetById(id);
        public async Task<ProductSaveResponseDTO> SaveOrUpdate(ProductSaveDTO productSave)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            ProductSaveResponseDTO response = await _productApplication.SaveOrUpdate(productSave);
            transaction.Complete();

            return response;
        }

        public async Task<int> Delete(int id)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            int response = await _productApplication.Delete(id);
            transaction.Complete();

            return response;
        }
    }
}
