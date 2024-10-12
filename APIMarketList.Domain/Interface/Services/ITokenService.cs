using APIMarketList.Domain.DTO.User;

namespace APIMarketList.Domain.Interface.Service
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
        string GetSecret();
        UserDTO GetUser();
    }
}
