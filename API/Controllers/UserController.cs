using AutoMapper;
using Core.Dto;
using Core.Entities;
using System.Net;
using Infraestructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public UserController(IUserRepository repo, IMapper mapper)
        {
            _response = new ResponseDto();
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<ActionResult<UserDto>> AddUserAsync([FromBody] UserDto userDto)
        {
            //Validar si el objeto que llega es nulo
            if (userDto == null)
            {
                _response.isSuccess = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.result = null;
                _response.message = "Datos Invalidos";

                return BadRequest(_response);
            }


            //Validar si el objeto es valido (para esto utilice los datannotation)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //Verificar si el usuario ya existe en la Db
            bool existsUser = await _repo.valitateUser(userDto);

            if (existsUser)
            {
                _response.isSuccess = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.result = null;
                _response.message = "El nombre de usuario ya existe en la base de datos";

                return BadRequest(_response);
            }


            //Mapeo del dto
            User user = _mapper.Map<User>(userDto);

            await _repo.insertUser(user);
            return Ok(user);
        }


    }
}
