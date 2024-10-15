using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APIMarketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : BaseController
    {
        private readonly IMemberApplication _memberApplication;
        public MemberController(IMemberApplication memberService, INotification notification) : base(notification)
        {
            _memberApplication = memberService;
        }
        [HttpPost("Invite")]
        public async Task<ActionResult<ResponseBaseViewModel>> Invite([FromBody] InviteMemberDTO shoppingList)
        {
            return await ExecuteResponseAsync(() => _memberApplication.Invite(shoppingList));
        }
        [HttpDelete("Remove")]
        public async Task<ActionResult<ResponseBaseViewModel>> Remove(int memberId)
        {
            return await ExecuteResponseAsync(() => _memberApplication.Remove(memberId));
        }
    }
}
