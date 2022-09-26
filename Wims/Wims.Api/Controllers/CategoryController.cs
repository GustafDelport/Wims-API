using Microsoft.AspNetCore.Mvc;

namespace Wims.Api.Controllers
{
    [Route("Category")]
    public class CategoryController : ApiController
    {
        [HttpGet]
        public IActionResult GetCategoriesAsync()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
