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
using APIProject.ViewModels;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IProvider prod;
        public FoodsController(IProvider prod)
        {
            this.prod = prod;
        }

        // GET: api/Foods
        [HttpGet]
        public async Task <ActionResult<List<Food>>> GetFood()
        {

            var response=await  prod.GetAll();
            return response != null ? Ok(response):NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFoodById(int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }
            var response = await prod.GetFoodById(id);
            return response != null ? Ok(response) : NotFound();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFood(int id, Food food)
        {
           
            if(!ModelState.IsValid||id<=0)
            {
                return BadRequest();
            }
            var response=await prod.EditFood(id, food);
            return response?Ok(response):NotFound();
        }

        // POST: api/Foods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food)
        {
            if (!ModelState.IsValid )
            {
                return BadRequest();
            }
            var response=await prod.AddNewFood(food);
            return CreatedAtAction("GetFood", new { id = food.FoodId }, food);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
          
            if (id <= 0)
            {
                return BadRequest();
            }
            var response =await prod.DeleteFood(id);
            return response ? NoContent() :NotFound() ;
           

        }

      
        [HttpGet("NewOrder")]

        public async Task<ActionResult<List<NewOrder>>> GetNewOrder()
        {
            var response = await prod.ViewNewOrder().ConfigureAwait(false);
            return response != null ? Ok(response) : NotFound();

        }
        //public async Task<IActionResult> GetNewOrder()
        //{
        //    var response=await prod.ViewNewOrder().ConfigureAwait(false);
        //    return Ok(response);
        //}

        [HttpGet("DispatchNewOrder{Id}")]
        public async Task<ActionResult<NewOrder>> DispatchNewOrder(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            var response = await prod.DispatchNewOrder(Id).ConfigureAwait(false);
            return response != null ? Ok(response) : NotFound();
        }
        [HttpPut("DispatchOrder{Id}")]

        public async Task<IActionResult> DispatchOrder(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            var response = await prod.DispatchOrder(Id).ConfigureAwait(false);
            return response  ? NoContent() : NotFound();
            
        }
        [HttpDelete("EmptyOrder{OrderId}")]
        public async Task<IActionResult> EmptyOrder(int OrderId)
        {
            if (OrderId <= 0)
            {
                return BadRequest();
            }
            var response = await prod.EmptyOrder(OrderId).ConfigureAwait(false);
            return response ? NoContent() : NotFound();

        }


    }
}
