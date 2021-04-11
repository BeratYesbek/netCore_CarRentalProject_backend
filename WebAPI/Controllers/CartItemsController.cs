using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : Controller
    {
        private ICartItemService _cartItemService;
        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost("add")]
        public IActionResult Add(CartItem cartItem)
        {
            var result = _cartItemService.Add(cartItem);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cartItemService.GetAll();
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _cartItemService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult delete(CartItem cartItem)
        {

            var result = _cartItemService.Delete(cartItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        } 

    }
}
