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

            return await prod.GetFoodById(id);
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
        public ActionResult<Cart> AddtoCart(Cart C)
        {
            return prod.AddtoCart(C);
            //return new JsonResult(C);
        }
        //[HttpPost]
        //public ActionResult<Cart> AddtoCart(Cart C)
        //{
        //    Cart A = prod.AddtoCart(C);
        //    return new JsonResult(A);
        //}

        [HttpGet("ViewCart{UserId}")]

        public ActionResult<List<Cart>> ViewCart(int UserId)
        {

            return prod.GetCartById(UserId);
        }
        [HttpGet("{UserId}")]

        public IActionResult viewCart(int UserId)
        {
            prod.ViewCart(UserId);
            return NoContent();
        }

        [HttpGet("Delete{CartId}")]
        public ActionResult<Cart> Delete(int CartId)
        {

            return prod.Delete(CartId);
        }
        [HttpPost("{CartId}")]
        public IActionResult DeleteConfirmed(int CartId)
        {
            prod.DeleteConfirmed(CartId);
            return NoContent();
        }
        [HttpDelete("EmptyList{UserId}")]
        public IActionResult EmptyList(int UserId)
        {
            prod.EmptyList(UserId);
            return NoContent();
        }
        [HttpGet("OrderDetails")]

        public ActionResult<List<OrderDetails>> OrderDetails()
        {

            return prod.OrderDetails();
        }
        [HttpGet("Buy{UserId}")]

        public ActionResult<OrderMaster> Buy(int UserId)
        {

            return prod.Buy(UserId);
        }
        [HttpPut("Payment{OrderId}")]
        //[HttpPost("Payment")]

        public ActionResult<OrderMaster> Payment(int OrderId,OrderMaster O)
        {

             return prod.Payment(OrderId,O.Type);
            
        }
        [HttpGet("On{OrderId}")]

        public ActionResult<OrderMaster> On(int OrderId)
        {

            return prod.Pay(OrderId);
        }
        [HttpPut("On{OrderId}")]

        public IActionResult On(int OrderId,OrderMaster O)
        {

            prod.Pay(OrderId, O);
            return NoContent();
        }
       
        [HttpGet("EditCart{CartId}")]
        public ActionResult<Cart> EditCart(int CartId)
        {

            return prod.GetCartByCartId(CartId);
        }
        [HttpPut("Edit{CartId}")]
        public IActionResult Edit(int CartId,Cart C)
        {
            prod.Edit(CartId,C);
            return NoContent();
        }
        [HttpGet("DCart{CartId}")]
        public ActionResult<Cart> DeleteCart(int CartId)
        {

            return prod.GetCartByCartId(CartId);
        }
        [HttpDelete("Delete{CartId}")]
        public IActionResult DeleteCartConfirmed(int CartId)
        {
            prod.DeleteCart(CartId);
            return NoContent();
        }
       

    }
}
