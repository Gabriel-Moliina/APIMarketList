﻿using APIMarketList.Application.Interface.Base;
using APIMarketList.Domain.DTO.Product;

namespace APIMarketList.Application.Interface
{
    public interface IProductApplication : IBaseApplication
    {
        Task<List<ProductDTO>> GetProductsAsync();
        Task<ProductDTO?> GetById(long id);
        Task<ProductSaveResponseDTO> SaveOrUpdate(ProductSaveDTO productSave);
    }
}
