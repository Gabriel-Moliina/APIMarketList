using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using AutoMapper;
using FluentValidation;

namespace APIMarketList.Application.Application
{
    public class ShoppingListApplication : BaseApplication, IShoppingListApplication
    {
        private readonly INotification _notification;
        private readonly IMapper _mapper;
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IValidator<ShoppingListSaveDTO> _validatorSave;
        public ShoppingListApplication(INotification notification,
            IShoppingListRepository shoppingListRepository,
            IMapper mapper,
            IValidator<ShoppingListSaveDTO> validatorSave
            )
        {
            _shoppingListRepository = shoppingListRepository;
            _notification = notification;
            _mapper = mapper;
            _validatorSave = validatorSave;
        }

        public async Task<ShoppingListDTO?> Get(int id) => await _shoppingListRepository.Get(id);
        public async Task<IList<ShoppingListDTO>> GetAll() => await _shoppingListRepository.GetAll();
        public async Task<IList<ShoppingListDTO>> GetByUser(int userId) => await _shoppingListRepository.GetByUser(userId);
    }
}
