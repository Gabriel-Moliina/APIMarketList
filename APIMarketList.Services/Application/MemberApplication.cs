using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Application.Interface;
using APIMarketList.Service.Interface;
using System.Transactions;

namespace APIMarketList.Application.Application
{
    public class MemberApplication : IMemberApplication
    {
        private readonly IMemberService _memberService;
        public MemberApplication(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task Invite(InviteMemberDTO inviteMember)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _memberService.Invite(inviteMember);

            transaction.Complete();
        }

        public async Task Remove(int memberId)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _memberService.Remove(memberId);

            transaction.Complete();
        }
    }
}
