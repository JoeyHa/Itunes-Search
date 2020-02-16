using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ItunesSearchData.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }
        public string Token { get; set; }
        [Timestamp]
        public byte[] CreatedOn { get; set; }
    }
}
