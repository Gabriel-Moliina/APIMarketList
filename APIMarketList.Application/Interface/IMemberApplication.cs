using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Application.Interface
{
    public interface IMemberApplication
    {
        Task InviteMember(InviteMemberDTO inviteMember);
    }
}
