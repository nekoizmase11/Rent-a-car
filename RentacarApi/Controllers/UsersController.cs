
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentacarApi.Business.DtoModels;
using RentacarApi.Business.Interfaces;
using RentacarApi.Models;

namespace RentacarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBusinessLayer _businessLayer;
        private readonly IMapper _mapper;

        public UsersController(IBusinessLayer businessLayer, IMapper mapper)
        {
            _businessLayer = businessLayer;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            try
            {
                return Ok(_businessLayer.UserService.GetAll().ToList());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var cuserDto = _businessLayer.UserService.GetUserById(id);

            if (cuserDto == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserModel>(cuserDto);
        }

       

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                UserDto userDto = _mapper.Map<UserDto>(user);
                UserDto created = _businessLayer.UserService.CreateUser(userDto);

                return CreatedAtAction("GetUser", new { id = created.Id }, _mapper.Map<UserModel>(created));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        

        
    }
}
