using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Application;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIMarketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : BaseController
    {
        private readonly IShoppingListApplication _shoppingListApplication;
        public ShoppingListController(IShoppingListApplication shoppingListService, INotification notification) : base(notification)
        {
            _shoppingListApplication = shoppingListService;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseViewModel<IList<ShoppingListDTO>>>> Get()
        {
            return await ExecuteResponseAsync(() => _shoppingListApplication.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseViewModel<ShoppingListDTO?>>> Get(int id)
        {
            return await ExecuteResponseAsync(() => _shoppingListApplication.Get(id));
        }

        [HttpGet("GetByUser")]
        public async Task<ActionResult<ResponseViewModel<IList<ShoppingListDTO>>>> GetByUser(int userId)
        {
            return await ExecuteResponseAsync(() => _shoppingListApplication.GetByUser(userId));
        }

        /// <summary>
        /// Adiciona ou altera uma lista de compra.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ResponseViewModel<ShoppingListSaveResponseDTO>>> Post([FromBody] ShoppingListSaveDTO shoppingList)
        {
            return await ExecuteResponseAsync(() => _shoppingListApplication.CreateNew(shoppingList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseVoidViewModel>> Delete(int id)
        {
            return await ExecuteResponseAsync(() => _shoppingListApplication.Delete(id));
        }
    }
}
