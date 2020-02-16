using ItunesSearchData;
using ItunesSearchData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text.Json;
namespace ItunesSearchServerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private ISearchService _searchService;
        private readonly ILogger<SearchController> _logger;
        private readonly ItunesSearchContext _context;
        private IAccountService _accountService;

        public SearchController(ISearchService searchService, IAccountService accountService, ILogger<SearchController> logger, ItunesSearchContext context)
        {
            _context = context;
            _searchService = searchService;
            _logger = logger;
            _accountService = accountService;
        }

        //Get search/query
        [HttpGet("{username}/{query}")]
        public SearchJson Index(string query, string username)
        {
            var searchResults = _searchService.GetSearchAsync(query);
            if (searchResults.Result != null)
            {
                var currentUser = _accountService.GetByUsername(username);
                if (currentUser == null)
                {
                    return null;
                }
                SaveSearchHistory(query, currentUser);
            }
            return searchResults.Result;
        }
        [HttpGet("Lookup/{id}")]
        //For Details of each entity from Itunes:
        //search/LookUp/id
        public SearchLookUp Lookup(int id)
        {
            var lookUpResults = _searchService.GetSearchLookUpAsync(id);
            return lookUpResults.Result;
        }

        //Will save to DB the histoy of query was searched by a user. 
        public void SaveSearchHistory(string query, Account account)
        {
            if (query == null || account == null)
            {
                return;
            }
            try
            {
                AccountData userData = new AccountData();
                userData.SearchValue = query;
                userData.User_Id = account.Id;
                _context.AccountData.Add(userData);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("Top/{userId}")]
        // Search/top/id
        public string GetTopTenSearch(int userId)
        {
            if (userId == 0)
            {
                return null;
            }
            var topSearch = _context.AccountData.OrderByDescending(v => v.User_Id).Take(10).ToList();
            var topSearchJson = System.Text.Json.JsonSerializer.Serialize(topSearch);
            return topSearchJson;
        }
    }

}
