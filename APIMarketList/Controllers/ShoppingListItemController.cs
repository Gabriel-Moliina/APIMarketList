using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Interface.Application;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIMarketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListItemController : BaseController
    {
        private readonly IShoppingListItemApplication _shoppingListItemApplication;

        public ShoppingListItemController(IShoppingListItemApplication shoppingListService, INotification notification) : base(notification)
        {
            _shoppingListItemApplication = shoppingListService;
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<ResponseVoidViewModel>> AddItem([FromBody] ShoppingListItemSaveDTO shoppingListItem)
        {
            return await ExecuteResponseAsync(() => _shoppingListItemApplication.AddItem(shoppingListItem));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseVoidViewModel>> RemoveItem(int id)
        {
            return await ExecuteResponseAsync(() => _shoppingListItemApplication.RemoveItem(id));
        }
    }
}
