using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBasic.DataBase.Entity
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public bool Married { get; set; }
        public string Memo { get; set; }
    }
}