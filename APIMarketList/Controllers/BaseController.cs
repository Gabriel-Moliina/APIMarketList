using APIMarketList.Domain.Interface.Notification;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIMarketList.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        private readonly INotification _notification;
        public BaseController(INotification notification)
        {
            _notification = notification;
        }

        protected async Task<ActionResult<ResponseViewModel<T>>> ExecuteResponseAsync<T>(Func<Task<T>> method)
        {
            try
            {
                var responseData = await method();
                var response = new ResponseViewModel<T>(_notification);
                response.SetData(responseData);

                var code = response.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;
                return StatusCode(code, response);
            }
            catch (Exception ex)
            {
                var response = new ResponseViewModel<T>(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        protected async Task<ActionResult<ResponseBaseViewModel>> ExecuteResponseAsync(Func<Task> method)
        {
            try
            {
                await method();
                var response = new ResponseBaseViewModel(_notification);
                var code = response.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;
                return StatusCode(code, response);
            }
            catch (Exception ex)
            {
                var response = new ResponseBaseViewModel(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
