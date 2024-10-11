﻿using APIMarketList.Application.Application.Base;
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
        public ShoppingListItemApplication(INotification notification,
            IMapper mapper,
            IValidator<ShoppingListItemSaveDTO> validatorSave,
            IShoppingListItemRepository shoppingListItemRepository,
            IMemberRepository memberRepository,
            ITokenService tokenService
            ) : base(mapper, notification, tokenService)
        {
            _shoppingListItemRepository = shoppingListItemRepository;
            _memberRepository = memberRepository;
            _validatorSave = validatorSave;
        }

        public async Task AddItem(ShoppingListItemSaveDTO saveShoppingListItemDTO)
        {
            _notification.AddNotification(await _validatorSave.ValidateAsync(saveShoppingListItemDTO));
            if (_notification.HasNotifications) return;

            var entity = _mapper.Map<ShoppingListItem>(saveShoppingListItemDTO);

            await _shoppingListItemRepository.AddAsync(_mapper.Map<ShoppingListItem>(saveShoppingListItemDTO));
        }

        public async Task RemoveItem(int id)
        {
            ShoppingListItem? entity = await _shoppingListItemRepository.Get(id);

            if (entity is null)
            {
                _notification.AddNotification("Item", "Item não encontrado");
                return;
            }

            await _shoppingListItemRepository.DeleteAsync(entity);
        }
    }
}
