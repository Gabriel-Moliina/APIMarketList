using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Service;
using FluentValidation;

namespace APIMarketList.Domain.Validator.ShoppingListItem
{
    public class ShoppingListItemPurchaseValidator : AbstractValidator<ShoppingListItemPurchaseDTO>
    {
        private readonly IShoppingListItemRepository _shoppingListItemRepository;
        private readonly ITokenService _tokenService;
        public ShoppingListItemPurchaseValidator(IShoppingListItemRepository shoppingListItemRepository,
            ITokenService tokenService)
        {
            _shoppingListItemRepository = shoppingListItemRepository;
            _tokenService = tokenService;

            RuleFor(x => x.ShoppingListItemId)
                .NotEmpty()
                .NotEqual(0)
                .MustAsync(async (model, code, cancellationtoken) =>
                {
                    return (await _shoppingListItemRepository.Get(model.ShoppingListItemId) != null);
                }).WithMessage("Item não encontrado");

            RuleFor(x => x.Amount)
                .NotEmpty()
                .NotEqual(0)
                .MustAsync(async (model, code, cancellationtoken) =>
                {
                    var item = await _shoppingListItemRepository.Get(model.ShoppingListItemId);
                    return !((item?.Amount - model.Amount) < 0);

                }).WithMessage("Quantidade inválida para o item selecionado");
        }
    }
}
