using Core.Dto;
using Infraestructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _login;
        private ResponseDto _response;
        public LoginController(ILoginRepository login)
        {
            _login = login;
            _response = new ResponseDto();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(UserLogin user)
        {
            if (user == null)
            {
                _response.isSuccess = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.message = "Datos no validos";

                return BadRequest(_response);
            }


            return Ok(await _login.Login(user));
        }
    }
}
