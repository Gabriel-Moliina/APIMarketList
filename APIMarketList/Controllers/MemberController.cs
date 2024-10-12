using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Application;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<ResponseVoidViewModel>> Invite([FromBody] InviteMemberDTO shoppingList)
        {
            return await ExecuteResponseAsync(() => _memberApplication.Invite(shoppingList));
        }
        [HttpDelete("Remove")]
        public async Task<ActionResult<ResponseVoidViewModel>> Remove(int shoppingListId, [FromQuery] string email)
        {
            return await ExecuteResponseAsync(() => _memberApplication.Remove(shoppingListId, email));
        }
    }
}
