using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIMarketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : BaseController
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService, INotification notification) : base(notification)
        {
            _memberService = memberService;
        }
        [HttpPost("Invite")]
        public async Task<ActionResult<ResponseVoidViewModel>> Invite([FromBody] InviteMemberDTO shoppingList)
        {
            return await ExecuteResponseAsync(() => _memberService.InviteMember(shoppingList));
        }
    }
}
