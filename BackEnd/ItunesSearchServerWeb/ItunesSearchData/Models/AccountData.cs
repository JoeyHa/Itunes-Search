using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItunesSearchData.Models
{
    public class AccountData
    {
        [Key]
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string SearchValue { get; set; }

    }
}
