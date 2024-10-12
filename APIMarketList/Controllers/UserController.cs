using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Interface.Application;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APIMarketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserApplication _userApplication;
        public UserController(IUserApplication userService, INotification notification) : base(notification)
        {
            _userApplication = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseViewModel<IList<UserDTO>>>> Get()
        {
            return await ExecuteResponseAsync(() => _userApplication.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseViewModel<UserDTO>>> Get(int id)
        {
            return await ExecuteResponseAsync(() => _userApplication.GetById(id));
        }

        /// <summary>
        /// Adiciona ou altera um usuário.
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ResponseViewModel<UserSaveResponseDTO>>> SaveOrUpdate([FromBody] UserSaveDTO userSave)
        {
            return await ExecuteResponseAsync(() => _userApplication.SaveOrUpdate(userSave));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseVoidViewModel>> Delete(int id)
        {
            return await ExecuteResponseAsync(() => _userApplication.Delete(id));
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult<ResponseViewModel<string>>> Authenticate(string login, string password)
        {
            return await ExecuteResponseAsync(() => _userApplication.Authenticate(login, password));
        }
    }
}
