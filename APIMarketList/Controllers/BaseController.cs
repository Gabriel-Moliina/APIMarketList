using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIMarketList.Controllers
{
    public class BaseController : ControllerBase
    {
        protected async Task<ActionResult<ResponseViewModel<T>>> ExecuteResponseAsync<T>(Func<Task<T>> method)
        {
            try
            {
                var responseData = await method();
                var response = new ResponseViewModel<T>(responseData);
                var code = response.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;
                return StatusCode(code, response);
            }
            catch (Exception ex)
            {
                var response = new ResponseViewModel<T>(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
