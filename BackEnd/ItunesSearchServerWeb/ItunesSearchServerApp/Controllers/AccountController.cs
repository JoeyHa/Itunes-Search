using ItunesSearchData;
using ItunesSearchData.Helpers;
using ItunesSearchData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ItunesSearchServerApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;
        private readonly AppSettings _appSettings;

        public AccountController(IOptions<AppSettings> appSettings, IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        //Post: account/Login
        public IActionResult Login([FromBody] Account account)
        {
            Account user = _accountService.Login(account.UserName, account.Password);
            if (user == null)
            {
                return BadRequest(new { message = "UserName or Password is incorrect" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);

            // remove password before returning
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                firstName = user.FirstName,
                lastName = user.LastName,
                Token = stringToken
            });
        }
        [AllowAnonymous]
        [HttpPost("register")]
        //Post: account/register
        public IActionResult Register([FromBody]Account user)
        {
            // map dto to entity
            //var user = _mapper.Map<Account>(user);
            Account newUser = new Account();
            newUser.UserName = user.UserName;
            newUser.Password = user.Password;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            try
            {
                // save 
                _accountService.Register(newUser, user.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userFromDB = _accountService.GetById(id);

            return Ok(userFromDB);
        }
    }
}
