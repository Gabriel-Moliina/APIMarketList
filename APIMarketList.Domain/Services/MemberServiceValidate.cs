using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Service;
using APIMarketList.Domain.Interface.Services;

namespace APIMarketList.Domain.Services
{
    public class MemberServiceValidate : IMemberServiceValidate
    {
        private readonly ITokenService _tokenService;
        private readonly IMemberRepository _memberRepository;
        private readonly INotification _notification;
        public MemberServiceValidate(ITokenService tokenService,
            IMemberRepository memberRepository,
            INotification notification)
        {
            _tokenService = tokenService;
            _notification = notification;
            _memberRepository = memberRepository;
        }

        public async Task ValidateMemberAdminShoppingList(int shoppingListId)
        {
            if (await _memberRepository.IsUserAdmin(shoppingListId, _tokenService.GetUser().Id))
                _notification.AddNotification("Usuário", "Usuário logado não é membro administrador da lista de compra");
        }
    }
}
