using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace APIMarketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService, INotification notification) : base(notification)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseViewModel<IList<UserDTO>>>> Get()
        {
            return await ExecuteResponseAsync(() => _userService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseViewModel<UserDTO>>> Get(int id)
        {
            return await ExecuteResponseAsync(() => _userService.GetById(id));
        }

        /// <summary>
        /// Adiciona ou altera um usuário.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ResponseViewModel<UserSaveResponseDTO>>> SaveOrUpdate([FromBody] UserSaveDTO userSave)
        {
            return await ExecuteResponseAsync(() => _userService.SaveOrUpdate(userSave));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseViewModel<int>>> Delete(int id)
        {
            return await ExecuteResponseAsync(() => _userService.Delete(id));
        }
    }
}
