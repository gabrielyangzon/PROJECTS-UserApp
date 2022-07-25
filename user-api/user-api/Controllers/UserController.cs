using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using user_access;
using user_data.types.Models;
using user_logger;
using user_services;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace user_api.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IloggerManager _logger;

        //private readonly User _CONTEXT;
        private readonly UserService _userService;

        public UserController(USER_CONTEXT context ,IloggerManager logger)
        {
            this._userService = new UserService(context);
            _logger = logger;
        }


        // GET: api/<UserController>
        [HttpGet]
        [ProducesResponseType(200)]
        [Route("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var allUser =  await this._userService.GetAllUsers();

            if(allUser.Count() == 0)
            {
                return NotFound();
            }

            _logger.LogInfo("Here is info message from the controller.");
            return Ok(allUser);
        }

        // GET api/<UserController>/5
        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult> Get(Guid id)
        {
            var user = await this._userService.GetUserById(id);

            if (user == null)
            {
                _logger.LogError("error");
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddUser([FromBody] User user)
        {
            try
            {
                await this._userService.AddUser(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("User Added");

        }

        // PUT api/<UserController>/5
        [HttpPut]
        [Route("EditUser")]
        public async Task<ActionResult> EditUser([FromBody] User user)
        {
            try
            {
                await this._userService.EditUser(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("User Modified");
        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await this._userService.DeleteUser(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("User Deleted");
        }
    }
}
