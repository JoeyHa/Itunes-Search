using ItunesSearchData;
using ItunesSearchData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace ItunesSearchServerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private ISearchService _searchService;
        private readonly ILogger<SearchController> _logger;
        private readonly ItunesSearchContext _context;

        public SearchController(ISearchService searchService, ILogger<SearchController> logger)
        {
            _searchService = searchService;
            _logger = logger;
        }

        //Get search/query
        [HttpGet("{query}")]
        public SearchJson Index(string query)
        {
            var searchResults = _searchService.GetSearchAsync(query);
            //if (searchResults.Result != null)
            //{
            //    SaveSearchHistory(string, account);
            //}
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
        public async void SaveSearchHistory(string query, Account account)
        {
            if (query == null || account == null)
            {
                return;
            }
            AccountData userData = new AccountData();
            userData.SearchTime = DateTime.Now;
            userData.SearchValue = query;
            userData.User_Id = account.Id;
            _context.Add(userData);
            await _context.SaveChangesAsync();

        }
    }

}
