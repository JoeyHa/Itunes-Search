using ItunesSearchData.Models;
using Microsoft.EntityFrameworkCore;

namespace ItunesSearchServerApp.Controllers
{
    public class ItunesSearchContext : DbContext
    {
        public ItunesSearchContext(DbContextOptions<ItunesSearchContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountData> AccountData { get; set; }

    }
}
