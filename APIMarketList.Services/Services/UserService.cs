using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.Infra.CrossCutting.Services;
using System.Transactions;

namespace APIMarketList.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserApplication _userApplication;
        public UserService(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public async Task<IList<UserDTO>> Get() => await _userApplication.Get();
        public async Task<UserDTO> GetById(int id) => await _userApplication.GetById(id);

        public async Task<UserSaveResponseDTO> SaveOrUpdate(UserSaveDTO userSaveDTO)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
            UserSaveResponseDTO response = await _userApplication.SaveOrUpdate(userSaveDTO);
            transaction.Complete();
            return response;
        }

        public async Task<int> Delete(int id)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
            int response = await _userApplication.Delete(id);
            transaction.Complete();
            return response;
        }

        public async Task<string> Authenticate(string login, string password) => await _userApplication.Authenticate(login, password);
    }
}
