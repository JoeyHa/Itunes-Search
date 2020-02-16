using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItunesSearchData.Models
{
    public class SearchLookUp
    {
        [JsonProperty("resultCount")]
        public int resultCount { get; set; }
        [JsonProperty("results")]
        public SearchDetails[] DetailsRes { get; set; }
    }
}
