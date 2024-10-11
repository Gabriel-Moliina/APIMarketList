using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Application.Interface
{
    public interface IMemberApplication
    {
        Task Invite(InviteMemberDTO inviteMember);
        Task Remove(int shoppingListId, string email);
    }
}
