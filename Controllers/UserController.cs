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
    public class UserController : ControllerBase
    {
        private readonly IProvider prod;
        public UserController(IProvider prod)
        {
            this.prod = prod;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<List<UserList>> UserDetails()
        {

            return prod.UserDetails();
        }

        // GET: api/User/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserList>> GetUserList(int id)
        //{
        //  if (_context.UserList == null)
        //  {
        //      return NotFound();
        //  }
        //    var userList = await _context.UserList.FindAsync(id);

        //    if (userList == null)
        //    {
        //        return NotFound();
        //    }

        //    return userList;
        //}

        //// PUT: api/User/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserList(int id, UserList userList)
        //{
        //    if (id != userList.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userList).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserListExists(id))
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

        //// POST: api/User
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UserList>> PostUserList(UserList userList)
        //{
        //  if (_context.UserList == null)
        //  {
        //      return Problem("Entity set 'FoodContext.UserList'  is null.");
        //  }
        //    _context.UserList.Add(userList);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUserList", new { id = userList.UserId }, userList);
        //}

        //// DELETE: api/User/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUserList(int id)
        //{
        //    if (_context.UserList == null)
        //    {
        //        return NotFound();
        //    }
        //    var userList = await _context.UserList.FindAsync(id);
        //    if (userList == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UserList.Remove(userList);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UserListExists(int id)
        //{
        //    return (_context.UserList?.Any(e => e.UserId == id)).GetValueOrDefault();
        //}
        [HttpGet("ViewReport{UserId}")]

        public ActionResult<List<Content>> ViewReport(int UserId)
        {

            return prod.GetReportById(UserId);
        }
    }
}
