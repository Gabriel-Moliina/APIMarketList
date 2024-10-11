using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Services;
using AutoMapper;
using FluentValidation;

namespace APIMarketList.Application.Application
{
    public class MemberApplication : BaseApplication, IMemberApplication
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<InviteMemberDTO> _validatorInviteMember;
        public MemberApplication(IMemberRepository memberRepository,
            IUserRepository userRepository,
            IMapper mapper,
            INotification notification,
            IValidator<InviteMemberDTO> validatorInviteMember,
            ITokenService tokenService) : base(mapper, notification, tokenService)
        {
            _memberRepository = memberRepository;
            _userRepository = userRepository;
            _validatorInviteMember = validatorInviteMember;
        }
        public async Task Invite(InviteMemberDTO inviteMember)
        {
            _notification.AddNotification(await _validatorInviteMember.ValidateAsync(inviteMember));
            if (_notification.HasNotifications) return;

            User? user = await _userRepository.GetByEmail(inviteMember.MemberEmail);
            Member newEntity = new()
            {
                CanUpdate = inviteMember.CanUpdate,
                UserId = user.Id,
                ShoppingListId = inviteMember.ShoppingListId
            };

            await _memberRepository.AddAsync(newEntity);
        }
        
        public async Task Remove(int shoppingListId, string email)
        {

        }
    }
}
