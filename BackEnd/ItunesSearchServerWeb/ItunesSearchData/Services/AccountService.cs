using ItunesSearchData.Helpers;
using ItunesSearchData.Models;
using ItunesSearchServerApp.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ItunesSearchData.Services
{
    public class AccountService : IAccountService
    {
        private readonly ItunesSearchContext _context;
        private readonly AppSettings _appSettings;

        public AccountService(IOptions<AppSettings> appSettings, ItunesSearchContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            Account user = _context.Accounts.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if (user == null)
            {
                return null;
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
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;
            return user;

        }
    }
}