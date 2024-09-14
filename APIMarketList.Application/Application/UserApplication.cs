using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using AutoMapper;

namespace APIMarketList.Application.Application
{
    public class UserApplication : BaseApplication, IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserApplication(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IList<UserDTO>> Get() => _mapper.Map<IList<UserDTO>>(await _userRepository.Get());
        public async Task<UserDTO> GetById(int id) => _mapper.Map<UserDTO>(await _userRepository.Get(id));

        public async Task<UserSaveResponseDTO> SaveOrUpdate(UserSaveDTO userSaveDTO)
        {
            User entity = _mapper.Map<User>(userSaveDTO);
            entity.Password = Cryptography.Hash(userSaveDTO.Password);
            return _mapper.Map<UserSaveResponseDTO>(await _userRepository.SaveOrUpdate(entity));
        }

        public async Task<int> Delete(int id)
        {
            User? entity = await _userRepository.Get(id);
            return entity is null ? throw new Exception("Usuário não encontrado") : await _userRepository.DeleteAsync(entity);
        }
    }
}
