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

        public async Task<ShoppingListSaveResponseDTO> CreateNew(ShoppingListSaveDTO shoppingList)
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

            return _mapper.Map<ShoppingListSaveResponseDTO>(newEntity);
        }

        public async Task<ShoppingListDTO?> Get(int id) => _mapper.Map<ShoppingListDTO>(await _shoppingListRepository.Get(id));
        public async Task<IList<ShoppingListDTO>> GetAll() => _mapper.Map<IList<ShoppingListDTO>>(await _shoppingListRepository.Get());
        public async Task<IList<ShoppingListDTO>> GetByUser(int userId) => _mapper.Map<IList<ShoppingListDTO>>(await _shoppingListRepository.GetByUser(userId));
        public async Task Delete(int id) {

            ShoppingList? entity = await _shoppingListRepository.Get(id);

            if (entity is null || !await _shoppingListRepository.IsUserInShoppingList(id, _tokenService.GetUser().Id))
            {
                _notification.AddNotification("Lista de compra", "Lista de compra não encontrado");
                return;
            }

            await _shoppingListRepository.DeleteAsync(entity);
        }
    }
}
