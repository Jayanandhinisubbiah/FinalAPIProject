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
    public class LoginController : ControllerBase
    {
        private readonly IProvider prod;
        public LoginController(IProvider prod)
        {
            this.prod = prod;
        }


       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       [HttpPost]
        [Route("Registration")]
        public ActionResult<UserList> PostUserList(UserList userList)
        {

            prod.AddNewUser(userList);
            //return NoContent();

            
            return userList;
            //return CreatedAtAction("GetUserList", new { id = userList.UserId }, userList);
        }



        //private bool UserListExists(int id)
        //{
        //    return (_context.UserList?.Any(e => e.UserId == id)).GetValueOrDefault();
        //}
        [HttpPost]
        [Route("Login")]
        public ActionResult<UserList> LoginUser(UserList userList)
        {
            UserList user=prod.Login(userList);
            return user;
        }
    }
}
