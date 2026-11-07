using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        IPasswordService passwordService = new PasswordService();
        PasswordsController passwordsController = new PasswordsController(passwordService);
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return userService.Get();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            if(userService.GetById(id) != null)
            {
                return userService.GetById(id);
            }
            return NoContent();
            
        }
        
        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
           
            int passwordStrength = (passwordsController.Post(user.Password)).Value;

            if (passwordStrength < 3)
            {
                return BadRequest();
            }
            user = userService.Post(user);
            return CreatedAtAction(nameof(Get),new {Id = user.Id }, user);
        }


        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] LoginUser loginUser)
        {
            
           if(userService.Login(loginUser)!= null)
           {
               return Ok(userService.Login(loginUser));
           } 
           return NoContent();
        }



        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User userToUpdate)
        {

            int passwordStrength = (passwordsController.Post(userToUpdate.Password)).Value;

            if (passwordStrength < 3)
            {
                return BadRequest();
            }
            userService.Put(id, userToUpdate);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
