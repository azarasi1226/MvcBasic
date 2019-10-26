using MvcBasic.DataBase.Entity;
using MvcBasic.ViewModels.ServerValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcBasic.ViewModels
{
    public class MemberViewModel
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        [Required(ErrorMessage = "{0}は必須です")]
        [RegularExpression("[^a-z-A-Z0-9]*", ErrorMessage = "{0}には半角英数字を含めないでください。")]
        public string Name { get; set; }

        [DisplayName("メールアドレス")]
        [EmailAddress(ErrorMessage = "メールアドレスの形式で入力してください。")]
        public string Email { get; set; }

        [DisplayName("メールアドレス(確認)")]
        [Compare(nameof(Email), ErrorMessage = "{1}と同じ内容を入力してください")]
        public string EmailConfirmed { get; set; }

        [DisplayName("生年月日")]
        [Required(ErrorMessage = "{0}は必須です。")]
        public DateTime Birth { get; set; }

        [DisplayName("既婚")]
        public bool Married { get; set; }

        [DisplayName("自己紹介")]
        [Blackword("薬物,薬,暴力,ポルノ,武器")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "{0}は{1}文字以内で入力してください。")]
        public string Memo { get; set; }

        // デフォルトコンストラクタ
        public MemberViewModel()
        {
            ;
        }
        // Mebmer → MemberViewModel
        public MemberViewModel(Member member)
        {
            this.Id = member.Id;
            this.Name = member.Name;
            this.Email = member.Email;
            this.EmailConfirmed = member.Email;
            this.Birth = member.Birth;
            this.Married = member.Married;
            this.Memo = member.Memo;
        }

        // MomberViewModel → Member
        public Member ToMember()
        {
            return new Member
            {
                Id = this.Id,
                Name = this.Name,
                Email = this.Email,
                Birth = this.Birth,
                Married = this.Married,
                Memo = this.Memo
            };
        }
    }
}