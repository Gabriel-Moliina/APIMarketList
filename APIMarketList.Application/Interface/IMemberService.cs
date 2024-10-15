using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Service.Interface
{
    public interface IMemberService
    {
        Task Invite(InviteMemberDTO inviteMember);
        Task Remove(int shoppingListId, int memberId);
    }
}
