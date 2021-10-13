using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductsAdmin;
using Shop.Database;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public AdminController(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }

        [HttpGet("products")]
        public IActionResult GetProducts() => Ok(new GetProducts(_ctx).Do());

        [HttpGet("products/{id}")]
        public IActionResult GetProducts(int id) => Ok(new GetProduct(_ctx).Do(id));

        [HttpPost("products")]
        public IActionResult CreateProducts(CreateProduct.ProductViewModel vm) => Ok(new CreateProduct(_ctx).Do(vm));

        [HttpDelete("products/{id}")]
        public IActionResult DeleteProduct(int id) => Ok(new DeleteProduct(_ctx).Do(id));

        [HttpPut("products")]
        public IActionResult UpdateProduct(UpdateProduct.ProductViewModel vm) => Ok(new UpdateProduct(_ctx).Do(vm));

    }
}
