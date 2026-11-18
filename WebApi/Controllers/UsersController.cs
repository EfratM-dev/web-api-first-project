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
        static IPasswordService passwordService = new PasswordService();
        PasswordsController passwordsController = new PasswordsController(passwordService);
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userService.Get();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            if(userService.GetById(id) != null)
            {
                return await userService.GetById(id);
            }
            return NoContent();
            
        }
        
        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
           
            int passwordStrength = (passwordsController.Post(user.Password)).Value;

            if (passwordStrength < 3)
            {
                return BadRequest();
            }
            user = await userService.Post(user);
            return CreatedAtAction(nameof(Get),new {Id = user.Id }, user);
        }


        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginUser loginUser)
        {
            
           if(await userService.Login(loginUser)!= null)
           {
               return Ok(await userService.Login(loginUser));
           } 
           return NoContent();
        }



        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User userToUpdate)
        {

            int passwordStrength = (passwordsController.Post(userToUpdate.Password)).Value;

            if (passwordStrength < 3)
            {
                return BadRequest();
            }
            await userService.Put(id, userToUpdate);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
