﻿using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.Product;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Entities;
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

        public async Task<List<ProductDTO>> GetProductsAsync() => _mapper.Map<List<ProductDTO>>(await _productRepository.Get());

        public async Task<ProductDTO?> GetById(long id) => _mapper.Map<ProductDTO>(await _productRepository.Get(id));

        public async Task<ProductSaveResponseDTO> SaveOrUpdate(ProductSaveDTO productSave)
        {
            Product entity = _mapper.Map<Product>(productSave);
            return _mapper.Map<ProductSaveResponseDTO>(await _productRepository.SaveOrUpdate(entity));
        }

        public async Task<int> Delete(int i)
        {
            Product? entity = await _productRepository.Get(i);
            return entity is null ? throw new Exception("") : await _productRepository.DeleteAsync(entity);
        }
    }
}
