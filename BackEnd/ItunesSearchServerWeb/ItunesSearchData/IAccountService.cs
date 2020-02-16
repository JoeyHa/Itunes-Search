using ItunesSearchData.Models;
using System.Collections.Generic;

namespace ItunesSearchData
{
    public interface IAccountService
    {
        Account Login(string username, string password);

        Account Register(Account user, string password);
        Account GetById(int id);
        Account GetByUsername(string username);
    }
}
