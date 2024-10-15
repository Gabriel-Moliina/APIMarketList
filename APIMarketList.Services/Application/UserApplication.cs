using APIMarketList.Domain.DTO.User;
using APIMarketList.Application.Interface;
using APIMarketList.Service.Interface;
using System.Transactions;

namespace APIMarketList.Service.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _userService;
        public UserApplication(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IList<UserDTO>> Get() => await _userService.Get();
        public async Task<UserDTO> GetById(int id) => await _userService.GetById(id);

        public async Task<UserSaveResponseDTO> SaveOrUpdate(UserSaveDTO userSaveDTO)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
            UserSaveResponseDTO response = await _userService.SaveOrUpdate(userSaveDTO);
            transaction.Complete();
            return response;
        }

        public async Task Delete(int id)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _userService.Delete(id);

            transaction.Complete();
        }

        public async Task<string> Authenticate(string login, string password) => await _userService.Authenticate(login, password);
    }
}
