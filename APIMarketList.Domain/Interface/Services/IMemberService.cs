using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Domain.Interface.Services
{
    public interface IMemberService
    {
        Task InviteMember(InviteMemberDTO inviteMember);
    }
}
