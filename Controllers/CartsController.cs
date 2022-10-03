using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Data;
using APIProject.Models;
using APIProject.Provider;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IProvider prod;
        public CartsController(IProvider prod)
        {
            this.prod = prod;
        }

        // GET: api/Carts
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        //{
        //  if (_context.Cart == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Cart.ToListAsync();
        //}

        //// GET: api/Carts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Cart>> GetCart(int id)
        //{
        //  if (_context.Cart == null)
        //  {
        //      return NotFound();
        //  }
        //    var cart = await _context.Cart.FindAsync(id);

        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    return cart;
        //}

        //// PUT: api/Carts/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCart(int id, Cart cart)
        //{
        //    if (id != cart.CartId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cart).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CartExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Carts
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Cart>> PostCart(Cart cart)
        //{
        //  if (_context.Cart == null)
        //  {
        //      return Problem("Entity set 'FoodContext.Cart'  is null.");
        //  }
        //    _context.Cart.Add(cart);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        //}

        //// DELETE: api/Carts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCart(int id)
        //{
        //    if (_context.Cart == null)
        //    {
        //        return NotFound();
        //    }
        //    var cart = await _context.Cart.FindAsync(id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cart.Remove(cart);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CartExists(int id)
        //{
        //    return (_context.Cart?.Any(e => e.CartId == id)).GetValueOrDefault();
        //}
        #region
        [HttpGet("AddtoCart{id}")]
        public async Task<ActionResult<Food>> AddtoCart(int? id)
        {
            //if (id <= 0)
            //{
            //    return BadRequest();
            //}
            var response = await prod.GetFoodById(id);
            //return response != null ? Ok(response) : NotFound();
            return Ok(response);
        }
        #endregion
        //[HttpPost]
        //[Route("AddtoCart")]
        //public ActionResult<Cart> AddtoCart(int Qnt, int FoodId, int UserId)
        //{
        //    Cart C = prod.AddtoCart(Qnt, FoodId, UserId);
        //    return new JsonResult(C);
        //}
        [HttpPost]
        [Route("AddtoCart")]
        public async Task<ActionResult<Cart>> AddtoCart(Cart C)
        {
           
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest();
                //}
                var response = await prod.AddtoCart(C);
                return Ok(response);
                
           
          
           
           
        }
        //[HttpPost]
        //public ActionResult<Cart> AddtoCart(Cart C)
        //{
        //    Cart A = prod.AddtoCart(C);
        //    return new JsonResult(A);
        //}

        [HttpGet("ViewCart{UserId}")]

        public async Task<ActionResult<List<Cart>>> ViewCart(int UserId)
        {
            //if (UserId <= 0)
            //{
            //    return BadRequest();
            //}
            var response=await prod.GetCartByUserId(UserId);
            return response != null ? Ok(response) : NotFound();
            //return Ok(response);
        }
        [HttpGet("{UserId}")]

        public async Task<IActionResult> viewCart(int UserId)
        {
            //if (UserId <= 0)
            //{
            //    return BadRequest();
            //}
            var response=await prod.ViewCart(UserId);
            //return response ? NoContent() : StatusCode(500);
            return NoContent();
        }

        [HttpGet("Delete{CartId}")]
        public async Task<ActionResult<Cart>> Delete(int CartId)
        {
            //if (CartId <= 0)
            //{
            //    return BadRequest();
            //}
            var response = await prod.Delete(CartId);
            //return response != null ? Ok(response) : NotFound();
            return Ok(response);
        }
        [HttpDelete("{CartId}")]
        public async Task<IActionResult> DeleteConfirmed(int CartId)
        {
            //if (CartId <= 0)
            //{
            //    return BadRequest();
            //}
            var response = await prod.DeleteConfirmed(CartId);
            return response ? NoContent() : NotFound();
            //return NoContent();
        }
        [HttpDelete("EmptyList{UserId}")]
        public async Task<IActionResult> EmptyList(int UserId)
        {
            //if (UserId <= 0)
            //{
            //    return BadRequest();
            //}
            var response = await prod.EmptyList(UserId);
            return response ? NoContent() : NotFound();
            //return NoContent();
        }
        [HttpGet("OrderDetails")]

        public async Task<ActionResult<List<OrderDetails>>> OrderDetails()
        {
            var response = await prod.OrderDetails();
            return response != null ? Ok(response) : NotFound();
            //return Ok(response);
        }
        [HttpGet("Buy{UserId}")]

        public async Task<ActionResult<OrderMaster>> Buy(int UserId)
        {

           
            var response = await prod.Buy(UserId);
            //return response != null ? Ok(response) : NotFound();
            return Ok(response);
        }
        [HttpPut("Payment{OrderId}")]
        //[HttpPost("Payment")]

        public async Task<ActionResult<OrderMaster>> Payment(int OrderId,OrderMaster O)
        {
            //if (!ModelState.IsValid || OrderId <= 0)
            //{
            //    return BadRequest();
            //}
            var response = await prod.Payment(OrderId, O.Type);
            //return response !=null? Ok(response) : NotFound();
            return Ok(response);
            
        }
        [HttpGet("On{OrderId}")]

        public async Task<ActionResult<OrderMaster>> On(int OrderId)
        {
            //    if (OrderId <= 0)
            //    {
            //        return BadRequest();
            //    }
            var response = await prod.Pay(OrderId);
            //return response != null ? Ok(response) : NotFound();
            return Ok(response);
        }
        [HttpPut("On{OrderId}")]

        public async Task<IActionResult> On(int OrderId,OrderMaster O)
        {
            //if (!ModelState.IsValid || OrderId <= 0)
            //{
            //    return BadRequest();
            //}
            var response = await prod.Pay(OrderId, O);
            //return response ? NoContent() : NotFound();
            return NoContent();
        }
       
        [HttpGet("EditCart{CartId}")]
        public async Task<ActionResult<Cart>> EditCart(int CartId)
        {
            //if (CartId <= 0)
            //{
            //    return BadRequest();
            //}
            var response = await prod.GetCartByCartId(CartId);
            //return response != null ? Ok(response) : NotFound();
            return Ok(response);

        }
        [HttpPut("Edit{CartId}")]
        public async Task<IActionResult> Edit(int CartId,Cart C)
        {
            await prod.Edit(CartId,C);
            return NoContent();
        }
        [HttpGet("DCart{CartId}")]
        public async Task<ActionResult<Cart>> DeleteCart(int CartId)
        {

            var response=await prod.GetCartByCartId(CartId);
            return Ok(response);
        }
        [HttpDelete("Delete{CartId}")]
        public async Task<IActionResult> DeleteCartConfirmed(int CartId)
        {
           await prod.DeleteCart(CartId);
            return NoContent();
        }
       

    }
}
