using APIMarketList.Domain.DTO.User;

namespace APIMarketList.Infra.Authentication.Interface
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
        string GetSecret();
    }
}
