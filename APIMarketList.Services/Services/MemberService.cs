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
        public async Task InviteMember(InviteMemberDTO inviteMember)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _memberApplication.InviteMember(inviteMember);

            transaction.Complete();
        }
    }
}
