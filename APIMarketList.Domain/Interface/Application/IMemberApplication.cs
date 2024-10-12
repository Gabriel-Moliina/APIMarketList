using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Domain.Interface.Application
{
    public interface IMemberApplication
    {
        Task Invite(InviteMemberDTO inviteMember);
        Task Remove(int shoppingListId, string email);
    }
}
