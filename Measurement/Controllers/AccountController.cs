using Measurement.Models;
using Measurement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Measurement.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserService _service;


        public AccountController(UserService service)
        {
            _service = service;
        }



        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _service.ReqisterUser(dto);
            return Ok();
        }


        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _service.GenerateJwt(dto);
            return Ok(token);
        }

    }
}
