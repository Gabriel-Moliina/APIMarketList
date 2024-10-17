using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Service;
using FluentValidation;

namespace APIMarketList.Domain.Validator.ShoppingListItem
{
    public class ShoppingListItemSaveValidator : AbstractValidator<ShoppingListItemSaveDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IShoppingListItemRepository _shoppingListItemRepository;
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly ITokenService _tokenService;
        public ShoppingListItemSaveValidator(IUserRepository userRepository,
            IShoppingListItemRepository shoppingListItemRepository,
            IShoppingListRepository shoppingListRepository,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _shoppingListItemRepository = shoppingListItemRepository;
            _shoppingListRepository = shoppingListRepository;
            _tokenService = tokenService;

            RuleFor(x => x.ShoppingListId)
                .NotEmpty()
                .NotEqual(0)
                .MustAsync(async (model, shoppingListItemId, cancellationtoken) =>
                {
                    return (await _shoppingListRepository.IsUserInShoppingList(shoppingListItemId, _tokenService.GetUser().Id));
                }).WithMessage("Lista de compra não encontrada");

            RuleFor(x => x.Amount)
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("Quantidade inválida para o item selecionado")
                .MustAsync(async (model, amount, cancellationtoken) =>
                {
                    return (await _shoppingListRepository.Exists(model.ShoppingListId));
                }).WithMessage("Item não encontrado");
        }
    }
}
