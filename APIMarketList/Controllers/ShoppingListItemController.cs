using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIMarketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListItemController : BaseController
    {
        private readonly IShoppingListItemService _shoppingListItemService;

        public ShoppingListItemController(IShoppingListItemService shoppingListService, INotification notification) : base(notification)
        {
            _shoppingListItemService = shoppingListService;
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<ResponseVoidViewModel>> AddItem([FromBody] ShoppingListItemSaveDTO shoppingListItem)
        {
            return await ExecuteResponseAsync(() => _shoppingListItemService.AddItem(shoppingListItem));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseVoidViewModel>> RemoveItem(ShoppingListItemRemoveDTO removeShoppingListItemDTO)
        {
            return await ExecuteResponseAsync(() => _shoppingListItemService.RemoveItem(removeShoppingListItemDTO));
        }
    }
}
