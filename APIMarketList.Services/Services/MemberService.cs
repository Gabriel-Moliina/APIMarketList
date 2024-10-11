using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Services;
using System.Transactions;

namespace APIMarketList.Services.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberApplication _memberApplication;
        public MemberService(IMemberApplication memberApplication)
        {
            _memberApplication = memberApplication;
        }
        public async Task Invite(InviteMemberDTO inviteMember)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _memberApplication.Invite(inviteMember);

            transaction.Complete();
        }

        public async Task Remove(int shoppingListId, string email)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _memberApplication.Remove(shoppingListId, email);

            transaction.Complete();
        }
    }
}
