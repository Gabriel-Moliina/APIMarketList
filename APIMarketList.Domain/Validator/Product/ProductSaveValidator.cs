using APIMarketList.Domain.DTO.Product;
using FluentValidation;

namespace APIMarketList.Domain.Validator.Product
{
    public class ProductSaveValidator : AbstractValidator<ProductSaveDTO>
    {
        public ProductSaveValidator()
        {
            
        }
    }
}
