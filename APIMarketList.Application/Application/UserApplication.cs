using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.CrossCutting.Cryptography;
using APIMarketList.Infra.CrossCutting.Services;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace APIMarketList.Application.Application
{
    public class UserApplication : BaseApplication, IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly EncryptKey _encryptKey;
        private readonly INotification _notification;
        private readonly IValidator<UserSaveDTO> _validator;
        public UserApplication(IUserRepository userRepository,
            IMapper mapper,
            INotification notification,
            IValidator<UserSaveDTO> validator,
            IOptions<EncryptKey> encryptKey)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _notification = notification ;
            _validator = validator;
            _encryptKey = encryptKey.Value;
        }

        public async Task<IList<UserDTO>> Get() => _mapper.Map<IList<UserDTO>>(await _userRepository.Get());
        public async Task<UserDTO> GetById(int id) => _mapper.Map<UserDTO>(await _userRepository.Get(id));

        public async Task<UserSaveResponseDTO?> SaveOrUpdate(UserSaveDTO userSaveDTO)
        {
            _notification.AddNotification(await _validator.ValidateAsync(userSaveDTO));
            if (_notification.HasNotifications) return null;

            User entity = _mapper.Map<User>(userSaveDTO);
            entity.Password = Cryptography.Encrypt(userSaveDTO.Password.Trim(), _encryptKey.Key, _encryptKey.IV);
            return _mapper.Map<UserSaveResponseDTO>(await _userRepository.SaveOrUpdate(entity));
        }

        public async Task<int> Delete(int id)
        {
            User? entity = await _userRepository.Get(id);
            return entity is null ? throw new Exception("Usuário não encontrado") : await _userRepository.DeleteAsync(entity);
        }
    }
}
