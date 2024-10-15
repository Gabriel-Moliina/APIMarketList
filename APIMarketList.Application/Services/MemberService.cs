using APIMarketList.Application.Application.Base;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Service;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.Domain.Services;
using APIMarketList.Service.Interface;
using AutoMapper;
using FluentValidation;

namespace APIMarketList.Service.Services
{
    public class MemberService : BaseService, IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<InviteMemberDTO> _validatorInviteMember;
        private readonly IMemberServiceValidate _memberServiceValidate;
        public MemberService(IMemberRepository memberRepository,
            IUserRepository userRepository,
            IMapper mapper,
            INotification notification,
            IValidator<InviteMemberDTO> validatorInviteMember,
            ITokenService tokenService,
            IMemberServiceValidate memberServiceValidate) : base(mapper, notification, tokenService)
        {
            _memberRepository = memberRepository;
            _userRepository = userRepository;
            _validatorInviteMember = validatorInviteMember;
            _memberServiceValidate = memberServiceValidate;
        }
        public async Task Invite(InviteMemberDTO inviteMember)
        {
            _notification.AddNotification(await _validatorInviteMember.ValidateAsync(inviteMember));
            if (_notification.HasNotifications) return;

            User user = await _userRepository.GetByEmail(inviteMember.MemberEmail);

            Member newEntity = new()
            {
                UserId = user.Id,
                ShoppingListId = inviteMember.ShoppingListId
            };

            await _memberRepository.AddAsync(newEntity);
        }
        
        public async Task Remove(int shoppingListId, int memberId)
        {
            Member? member = await _memberRepository.Get(memberId);

            if (member is null)
                _notification.AddNotification("Membro", "Membero não encontrado");

            await _memberServiceValidate.ValidateMemberAdminShoppingList(shoppingListId);

            if(_notification.HasNotifications) return;

            await _memberRepository.DeleteAsync(member);
        }
    }
}
