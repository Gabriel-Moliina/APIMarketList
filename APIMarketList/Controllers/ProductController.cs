using APIMarketList.Domain.DTO;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIMarketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseViewModel<IList<ProductDTO>>>> Get()
        {
            return await ExecuteResponseAsync(() => _productService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseViewModel<ProductDTO?>>> Get(long id)
        {
            return await ExecuteResponseAsync(() => _productService.Get(id));
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
