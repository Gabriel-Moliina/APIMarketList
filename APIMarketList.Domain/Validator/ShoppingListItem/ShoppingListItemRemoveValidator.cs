using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Interface.Repositories;
using FluentValidation;

namespace APIMarketList.Domain.Validator.ShoppingListItem
{
    public class ShoppingListItemRemoveValidator : AbstractValidator<ShoppingListItemRemoveDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IShoppingListItemRepository _shoppingListItemRepository;
        public ShoppingListItemRemoveValidator(IUserRepository userRepository,
            IShoppingListItemRepository shoppingListItemRepository)
        {
            _userRepository = userRepository;
            _shoppingListItemRepository = shoppingListItemRepository;


        }
    }
}
