using digitaldiaryBackend.Context;
using digitaldiaryBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace digitaldiaryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public int id;
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]

        public async Task<IActionResult>Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Username == userObj.Username && x.Password==userObj.Password);
            
            if (user == null)
                return NotFound(new { Message = "User Not found!"  });
            id = user.Id;
            GetSessionValue(id.ToString());
            return Ok(new
            { Message = "Login Success!"
           
            }) ;
            
        }

        [HttpGet]
        public IActionResult GetSessionValue(string key)
        {
            string value = HttpContext.Session.GetString(key);
            return Ok(value);
        }
        
       
        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            
            return Ok(new
            {
                Message = " User Registered !"
            });


        }

    }
}
