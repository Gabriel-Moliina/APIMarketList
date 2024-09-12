using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.Product;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using AutoMapper;
using System.Transactions;

namespace APIMarketList.Application.Application
{
    public class ProductApplication : BaseApplication, IProductApplication
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository, 
            IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> GetProductsAsync() => await _productRepository.GetProductsAsync();

        public async Task<ProductDTO?> GetById(long id) => await _productRepository.GetById(id);

        public async Task<ProductSaveResponseDTO> SaveOrUpdate(ProductSaveDTO productSave)
        {
            var entity = _mapper.Map<Product>(productSave);
            return _mapper.Map<ProductSaveResponseDTO>(await _productRepository.SaveOrUpdate(entity));
        }
    }
}
