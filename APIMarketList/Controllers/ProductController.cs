using APIMarketList.Domain.DTO.Product;
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

        /// <summary>
        /// Adiciona ou altera um produto.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ProductSaveResponseDTO), 200)]
        public async Task<ActionResult<ResponseViewModel<ProductSaveResponseDTO>>> SaveOrUpdate([FromBody] ProductSaveDTO productSave)
        {
            return await ExecuteResponseAsync(() => _productService.SaveOrUpdate(productSave));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
