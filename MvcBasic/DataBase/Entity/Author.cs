using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBasic.DataBase.Entity
{
    public class Author
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        public string Name { get; set; }

        [DisplayName("メールアドレス")]
        public string Email { get; set;}

        [DisplayName("生年月日")]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime Birth { get; set; }

        [DisplayName("記事")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}