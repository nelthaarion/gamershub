using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using Angular.Models;
using Angular.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Angular.Data;
using Microsoft.AspNetCore.Authorization;

namespace Angular.Controllers {

    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase {
        private readonly IUserRepository _user;
        private readonly IMapper _iMapper;
        private  readonly IConfiguration _config;

        public AuthController (IMapper iMapper, IUserRepository user , IConfiguration config)
        {
            this._iMapper = iMapper;
            this._user = user;
            _config = (IConfigurationRoot) config;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserLoginDto user) 
        {
            user.Username =  user.Username.ToLower();
            if ( await _user.UserExist(user.Username))
                return BadRequest("User Exist");

            var createdUSer = await _user.Register(_iMapper.Map<User>(user));

            return StatusCode(201);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto user) 
        {
            user.Username =  user.Username.ToLower().Trim();
            if( !await _user.UserExist(user.Username))
            {
                return Unauthorized("USER DOESN'T");
            }
            var foundUser = await _user.Login(user);
            if(foundUser == null)
                 {
                                 return Unauthorized();
                 }

                    var token = Utilities.SignJwtToken(foundUser , _config);
                    return Ok(new { token });
                 
        }
        
        [HttpGet("test")]
        public  IActionResult Test() 
        {
            return Ok(new []{1,2,3,4});
        }

    }

}