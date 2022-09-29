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
        public async Task<ActionResult<UserList>> PostUserList(UserList userList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await prod.AddNewUser(userList);
            //prod.AddNewUser(userList);


            return userList;
        }



        
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserList>> LoginUser(UserList userList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            UserList user=await prod.Login(userList);
            return user;
        }
    }
}
