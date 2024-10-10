using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Services;
using AutoMapper;
using FluentValidation;

namespace APIMarketList.Application.Application
{
    public class ShoppingListApplication : BaseApplication, IShoppingListApplication
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IValidator<ShoppingListSaveDTO> _validatorSave;
        public ShoppingListApplication(INotification notification,
            IMapper mapper,
            IValidator<ShoppingListSaveDTO> validatorSave,
            IShoppingListRepository shoppingListRepository,
            IMemberRepository memberRepository,
            ITokenService tokenService
            ) : base(mapper, notification, tokenService)
        {
            _shoppingListRepository = shoppingListRepository;
            _memberRepository = memberRepository;
            _validatorSave = validatorSave;
        }

        public async Task<ShoppingListDTO> CreateNew(ShoppingListSaveDTO shoppingList)
        {
            _notification.AddNotification(await _validatorSave.ValidateAsync(shoppingList));
            if (_notification.HasNotifications) return null;

            ShoppingList newEntity = await _shoppingListRepository.SaveOrUpdate(_mapper.Map<ShoppingList>(shoppingList));

            if (shoppingList.Id == 0)
                await _memberRepository.AddAsync(new Member
                {
                    IsAdmin = true,
                    CanUpdate = true,
                    UserId = _tokenService.GetUser().Id,
                    ShoppingListId = newEntity.Id,
                });

            return _mapper.Map<ShoppingListDTO>(newEntity);
        }

        public async Task<ShoppingListDTO?> Get(int id) => await _shoppingListRepository.Get(id);
        public async Task<IList<ShoppingListDTO>> GetAll() => await _shoppingListRepository.GetAll();
        public async Task<IList<ShoppingListDTO>> GetByUser(int userId) => await _shoppingListRepository.GetByUser(userId);
    }
}
