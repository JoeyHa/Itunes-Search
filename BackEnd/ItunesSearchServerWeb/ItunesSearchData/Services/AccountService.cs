using ItunesSearchData.Helpers;
using ItunesSearchData.Models;
using ItunesSearchServerApp.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ItunesSearchData.Services
{
    public class AccountService : IAccountService
    {
        private readonly ItunesSearchContext _context;
        private readonly AppSettings _appSettings;

        public AccountService(ItunesSearchContext context)
        {
            _context = context;
        }
        [HttpGet]
        public Account Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            Account user = _context.Accounts.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            return user;
        }
        public Account Register(Account user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new MissingFieldException("Password is required");

            if (_context.Accounts.Any(x => x.UserName == user.UserName))
                throw new Exception("Username '" + user.UserName + "' is already taken");

            //byte[] passwordHash, passwordSalt;
            //CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //user.PasswordHash = passwordHash;
            //user.PasswordSalt = passwordSalt;

            _context.Accounts.Add(user);
            _context.SaveChanges();
            return user;
        }
        public Account GetById(int id)
        {
            return _context.Accounts.Find(id);
        }
        public Account GetByUsername(string username)
        {
            return _context.Accounts.Where(x => x.UserName == username).FirstOrDefault();
        }
    }
}