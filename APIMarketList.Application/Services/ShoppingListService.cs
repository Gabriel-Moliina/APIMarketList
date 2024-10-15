using APIMarketList.Application.Application.Base;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Service;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.Service.Interface;
using AutoMapper;
using FluentValidation;

namespace APIMarketList.Service.Services
{
    public class ShoppingListService : BaseService, IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IValidator<ShoppingListSaveDTO> _validatorSave;
        private readonly IMemberServiceValidate _memberServiceValidate;
        public ShoppingListService(INotification notification,
            IMapper mapper,
            IValidator<ShoppingListSaveDTO> validatorSave,
            IShoppingListRepository shoppingListRepository,
            IMemberRepository memberRepository,
            ITokenService tokenService,
            IMemberServiceValidate memberServiceValidate
            ) : base(mapper, notification, tokenService)
        {
            _shoppingListRepository = shoppingListRepository;
            _memberRepository = memberRepository;
            _validatorSave = validatorSave;
            _memberServiceValidate = memberServiceValidate;
        }

        public async Task<ShoppingListSaveResponseDTO> CreateNew(ShoppingListSaveDTO shoppingList)
        {
            _notification.AddNotification(await _validatorSave.ValidateAsync(shoppingList));
            if (_notification.HasNotifications) return null;

            ShoppingList newEntity = await _shoppingListRepository.SaveOrUpdate(_mapper.Map<ShoppingList>(shoppingList));

            if (shoppingList.Id == 0)
                await _memberRepository.AddAsync(new Member
                {
                    UserId = _tokenService.GetUser().Id,
                    ShoppingListId = newEntity.Id,
                    IsAdmin = true
                });

            return _mapper.Map<ShoppingListSaveResponseDTO>(newEntity);
        }

        public async Task<ShoppingListDTO?> Get(int id) => _mapper.Map<ShoppingListDTO>(await _shoppingListRepository.Get(id));
        public async Task<IList<ShoppingListDTO>> GetAll() => _mapper.Map<IList<ShoppingListDTO>>(await _shoppingListRepository.Get());
        public async Task<IList<ShoppingListDTO>> GetByUser(int userId) => _mapper.Map<IList<ShoppingListDTO>>(await _shoppingListRepository.GetByUser(userId));
        public async Task Delete(int id) {

            ShoppingList? entity = await _shoppingListRepository.Get(id);

            if (entity is null)
                _notification.AddNotification("Lista de compra", "Lista de compra não encontrado");

            await _memberServiceValidate.ValidateMemberAdminShoppingList(id);

            if (_notification.HasNotifications) return;

            await _shoppingListRepository.DeleteAsync(entity);
        }
    }
}
