using APIMarketList.Application.Application.Base;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Entities;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Service;
using APIMarketList.Service.Interface;
using AutoMapper;
using FluentValidation;
using System.Transactions;

namespace APIMarketList.Service.Services
{
    public class MemberService : BaseService, IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IValidator<InviteMemberDTO> _validatorInviteMember;
        public MemberService(IMemberRepository memberRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
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

            User user = await _userRepository.GetByEmail(inviteMember.MemberEmail);
            Role role = await _roleRepository.GetByName(inviteMember.RoleName);

            Member newEntity = new()
            {
                UserId = user.Id,
                ShoppingListId = inviteMember.ShoppingListId,
                RoleId = role.Id,
            };

            await _memberRepository.AddAsync(newEntity);
        }
        
        public async Task Remove(int memberId)
        {
            Member? member = await _memberRepository.Get(memberId);

            if (member is null)
            {
                _notification.AddNotification("Membro", "Membero não encontrado");
                return;
            }

            await _memberRepository.DeleteAsync(member);
        }
    }
}
