using ItunesSearchData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItunesSearchData
{
    public interface ISearchService
    {
        Task<List<Search>> GetAllAsync();
        Task<SearchJson> GetSearchAsync(string query);
        Task<SearchLookUp> GetSearchLookUpAsync(int id);

    }
}