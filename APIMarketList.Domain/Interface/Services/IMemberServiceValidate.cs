namespace APIMarketList.Domain.Interface.Services
{
    public interface IMemberServiceValidate
    {
        Task ValidateMemberAdminShoppingList(int shoppingListId);
    }
}
