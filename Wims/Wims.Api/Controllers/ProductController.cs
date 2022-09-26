using Microsoft.AspNetCore.Mvc;

namespace Wims.Api.Controllers
{
    [Route("Product")]
    public class ProductController : ApiController
    {
        [HttpGet]
        public IActionResult GetProductsAsync()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
