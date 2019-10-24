using MvcBasic.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MvcBasic.DataBase.Model
{
    public class MvcBasicInitializer : DropCreateDatabaseAlways<MvcBasicContext>
    {
        protected override void Seed(MvcBasicContext context)
        {
            // メンバーの初期化
            var members = new List<Member>
            {
                new Member
                {
                    Name = "山田リオ",
                    Email = "rio@wings.msn.to",
                    Birth = DateTime.Parse("1980-06-25"),
                    Married = false,
                    Memo = "ピアノが好きです。"
                },
                new Member
                {
                    Name = "日尾直弘",
                    Email = "naohiro@wings.msn.to",
                    Birth = DateTime.Parse("1975-07-19"),
                    Married = false,
                    Memo = "子供にも優しいお医者さんです。"
                },
                new Member
                {
                    Name = "掛谷直美",
                    Email = "naomi@wings.msn.to",
                    Birth = DateTime.Parse("1985-08-09"),
                    Married = false,
                    Memo = "フラワーアレンジメントを勉強中です"
                },
                new Member
                {
                    Name = "木村次郎",
                    Email = "jiro@wings.msn.to",
                    Birth = DateTime.Parse("1970-12-15"),
                    Married = true,
                    Memo = "山登りが趣味です。休日はよく山へ出かけます。"
                },
                new Member
                {
                    Name = "鈴木恵子",
                    Email = "keiko@wings.msn.to",
                    Birth = DateTime.Parse("1984-11-23"),
                    Married = true,
                    Memo = "子供と一緒にアニメを見るのが好きです。"
                }
            };


            members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
        }
    }
}