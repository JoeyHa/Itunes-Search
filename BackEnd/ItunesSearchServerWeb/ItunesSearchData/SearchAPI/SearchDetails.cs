using System;
using System.Collections.Generic;
using System.Text;

namespace ItunesSearchData.Models
{
    public class SearchDetails
    {
        public string wrapperType { get; set; }
        public string artistType { get; set; }
        public string artistName { get; set; }
        public string trackName { get; set; }
        public string artworkUrl100 { get; set; }
        public string artistLinkUrl { get; set; }
        public int artistId { get; set; }
        public int amgArtistId { get; set; }
        public string primaryGenreName { get; set; }
        public int primaryGenreId { get; set; }
        public string previewUrl { get; set; }
        public double trackPrice { get; set; }
        public string currency { get; set; }

    }
}
