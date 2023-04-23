using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using PizzaStore.Database.Entities;
using PizzaStore.Mapper;
using PizzaStore.Models;
using PizzaStore.Services.Cart.Contract;
using PizzaStore.Services.Product;
using PizzaStore.Services.Toppings;


namespace PizzaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartItemService cartItemService;

        public CartController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
        }


        [HttpGet]
        public async Task<ActionResult<List<CartItemModel>>> Get()
        {

            var cartItems = await cartItemService.GetAll();

            var result = cartItems?.Select(cartItem => MapCartItems(cartItem)).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CartItemModel cartItemModel)
        {
            CartItem cartItem = new CartItem
            {
                ProductId = cartItemModel.ProductId,
                Quantity = cartItemModel.Quantity,
                Price = cartItemModel.Price,
                CartItemToppings = cartItemModel.Toppings?.Select(a =>
                    new CartItemTopping
                    {
                        ToppingId = a.Id
                    }).ToList()
            };

            await cartItemService.Add(cartItem);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await cartItemService.Delete(id);
            return Ok();
        }

        private static CartItemModel MapCartItems(Database.Entities.CartItem cartItem)
        {

            return new CartItemModel
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price,
                ProductModel = ProductMapper.MapProduct(cartItem.Product)
            };
        }
    }
}
