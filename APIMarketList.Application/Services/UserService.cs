using APIMarketList.Application.Application.Base;
using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Service;
using APIMarketList.Infra.CrossCutting.Cryptography;
using APIMarketList.Infra.CrossCutting.Services;
using APIMarketList.Service.Interface;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace APIMarketList.Service.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly EncryptKey _encryptKey;
        private readonly IValidator<UserSaveDTO> _validator;
        public UserService(IUserRepository userRepository,
            IMapper mapper,
            INotification notification,
            IValidator<UserSaveDTO> validator,
            IOptions<EncryptKey> encryptKey,
            ITokenService tokenService) : base(mapper, notification, tokenService)
        {
            _userRepository = userRepository;
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

        public async Task Delete(int id)
        {
            User? entity = await _userRepository.Get(id);

            if(entity is null)
            {
                _notification.AddNotification("Usuário", "Usuário não encontrado");
                return;
            }

            await _userRepository.DeleteAsync(entity);
        }

        public async Task<string> Authenticate(string email, string password)
        {
            password = Cryptography.Encrypt(password.Trim(), _encryptKey.Key, _encryptKey.IV);
            User? user = await _userRepository.Login(email, password);

            if (user is null)
            {
                _notification.AddNotification("Usuário", "Usuário não encontrado");
                return null;
            }

            return _tokenService.GenerateToken(_mapper.Map<UserDTO>(user));
        }
    }
}
