using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Domain.Interface.Services
{
    public interface IMemberService
    {
        Task Invite(InviteMemberDTO inviteMember);
        Task Remove(int shoppingListId, string email);
    }
}
