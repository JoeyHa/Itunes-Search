using ItunesSearchData;
using ItunesSearchData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItunesSearchServerApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;


        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Account account)
        {
            Account user = _accountService.Login(account.UserName, account.Password);
            if (user == null)
            {
                return BadRequest(new { message = "UserName or Password is incorrect" });
            }
            return Ok(new
            {
                Id = account.Id,
                Username = account.UserName,
                Name = account.Name,
                //Token = tokenString
            });
        }
    }
}
