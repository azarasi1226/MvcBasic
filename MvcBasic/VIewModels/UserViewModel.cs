using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBasic.ViewModels
{
    public class UserViewModel
    {
        [DisplayName("ユーザーネーム")]
        [Required(ErrorMessage = "{0}は必須です")]
        public string UserName { get; set; }

        [DisplayName("パスワード")]
        [Required(ErrorMessage = "{0}は必須です")]
        [MinLength(6, ErrorMessage = "{0}は最低6文字以上入力してください")]
        public string Password { get; set; }
    }
}