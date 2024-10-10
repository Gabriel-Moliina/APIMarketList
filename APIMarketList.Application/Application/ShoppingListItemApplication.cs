using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Services;
using AutoMapper;
using FluentValidation;

namespace APIMarketList.Application.Application
{
    public class ShoppingListItemApplication : BaseApplication, IShoppingListItemApplication
    {
        private readonly IShoppingListItemRepository _shoppingListItemRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IValidator<ShoppingListItemSaveDTO> _validatorSave;
        private readonly IValidator<ShoppingListItemRemoveDTO> _validatorRemove;
        public ShoppingListItemApplication(INotification notification,
            IMapper mapper,
            IValidator<ShoppingListItemSaveDTO> validatorSave,
            IValidator<ShoppingListItemRemoveDTO> validatorRemove,
            IShoppingListItemRepository shoppingListItemRepository,
            IMemberRepository memberRepository,
            ITokenService tokenService
            ) : base(mapper, notification, tokenService)
        {
            _shoppingListItemRepository = shoppingListItemRepository;
            _memberRepository = memberRepository;
            _validatorSave = validatorSave;
            _validatorRemove = validatorRemove;
        }

        public async Task AddItem(ShoppingListItemSaveDTO saveShoppingListItemDTO)
        {
            _notification.AddNotification(await _validatorSave.ValidateAsync(saveShoppingListItemDTO));
            if (_notification.HasNotifications) return;

            await _shoppingListItemRepository.AddAsync(_mapper.Map<ShoppingListItem>(saveShoppingListItemDTO));
        }

        public async Task RemoveItem(ShoppingListItemRemoveDTO removeShoppingListItemDTO)
        {
            _notification.AddNotification(await _validatorRemove.ValidateAsync(removeShoppingListItemDTO));
            if (_notification.HasNotifications) return;

            ShoppingListItem? entityDelete = await _shoppingListItemRepository.GetByIndexShoppingListId(removeShoppingListItemDTO.Index, removeShoppingListItemDTO.ShoppingListId);
            await _shoppingListItemRepository.DeleteAsync(entityDelete);
        }
    }
}
