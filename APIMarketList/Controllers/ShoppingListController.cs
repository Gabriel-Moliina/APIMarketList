using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.Services.Services;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIMarketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : BaseController
    {
        private readonly IShoppingListService _shoppingListService;
        public ShoppingListController(IShoppingListService shoppingListService, INotification notification) : base(notification)
        {
            _shoppingListService = shoppingListService;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseViewModel<IList<ShoppingListDTO>>>> Get()
        {
            return await ExecuteResponseAsync(() => _shoppingListService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseViewModel<ShoppingListDTO?>>> Get(int id)
        {
            return await ExecuteResponseAsync(() => _shoppingListService.Get(id));
        }

        [HttpGet("GetByUser")]
        public async Task<ActionResult<ResponseViewModel<IList<ShoppingListDTO>>>> GetByUser(int userId)
        {
            return await ExecuteResponseAsync(() => _shoppingListService.GetByUser(userId));
        }

        /// <summary>
        /// Adiciona ou altera uma lista de compra.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ResponseViewModel<ShoppingListSaveResponseDTO>>> Post([FromBody] ShoppingListSaveDTO shoppingList)
        {
            return await ExecuteResponseAsync(() => _shoppingListService.CreateNew(shoppingList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseVoidViewModel>> Delete(int id)
        {
            return await ExecuteResponseAsync(() => _shoppingListService.Delete(id));
        }
    }
}
