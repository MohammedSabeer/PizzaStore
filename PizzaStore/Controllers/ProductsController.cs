using Microsoft.AspNetCore.Mvc;
using PizzaStore.Mapper;
using PizzaStore.Models;
using PizzaStore.Services.Product.Contract;
using PizzaStore.Services.Toppings.Contract;


namespace PizzaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IToppingService toppingService;

        public ProductsController(IProductService productService, IToppingService toppingService )
        {
            this.productService = productService;
            this.toppingService = toppingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> Get()
        {

            var products = await productService.GetProducts();
            var toppings = await toppingService.Get();

            var result = products.Select(product => ProductMapper.MapProduct(product, toppings)).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel?>> Get(int id)
        {

            var product = await productService.Get(id);
            var toppings = await toppingService.Get();

            if (product != null)
            {
                return ProductMapper.MapProduct(product, toppings);
            }

            return BadRequest();
        }

      
    }
}
