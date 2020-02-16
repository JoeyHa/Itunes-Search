using ItunesSearchData.Models;
using System.Collections.Generic;

namespace ItunesSearchData
{
    public interface IAccountService
    {
        Account Login(string username, string password);
        IEnumerable<Account> GetAll();
    }
}
