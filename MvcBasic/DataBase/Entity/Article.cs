using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBasic.DataBase.Entity
{
    public class Article
    {
        public int Id { get; set; }

        [DisplayName("URL")]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [DisplayName("タイトル")]
        public string Title { get; set; }

        [DisplayName("カテゴリ")]
        public CategoryEnum Category { get; set; }

        [DisplayName("概要")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("ビュー数")]
        public int Viewcount { get; set; }

        [DisplayName("公開日")]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime Published { get; set; }

        [DisplayName("公開済み")]
        public bool Released { get; set; }

        [DisplayName("コメント")]
        public virtual ICollection<Comment> Comments { get; set; }

        [DisplayName("著者")]
        public virtual ICollection<Author> Authors { get; set; }
    }

    public enum CategoryEnum
    {
        [Display(Name = ".NET")]
        DotNet,

        [Display(Name = "クラウド")]
        Cloud,

        [Display(Name = "リファレンス")]
        Reference
    }
}