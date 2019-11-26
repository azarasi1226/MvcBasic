using System;
using System.Web.Mvc;

namespace MvcBasic.Controllers.Filter.Authorization
{
    /// <summary>
    /// 期間限定アクセスを設定できる承認フィルター
    /// </summary>
    public class TimeLimiteAttribute : FilterAttribute, IAuthorizationFilter
    {
        private DateTime _first = DateTime.MinValue;
        private DateTime _last  = DateTime.MaxValue;

        public string First
        {
            set
            {
                var date = DateTime.Parse(value);

                this._first = date;
            }
        }

        public string Last
        {
            set
            {
                var date = DateTime.Parse(value);

                this._last = date;
            }
        }

        public TimeLimiteAttribute(string first, string last)
        {
            this.First = first;
            this.Last  = last;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("コンテントがnullです");
            }

            var current = DateTime.Now;
            if (!(this._first <= current && current <= this._last))
            {
                var msg = String.Format("このページは{0}から{1}までの期間のみ有効です",
                    this._first.ToLongDateString(),
                    this._last.ToLongDateString());

                filterContext.Result = new ContentResult
                {
                    Content = msg
                };
            }
        }
    }

    //時間切れを表す例外
    [Serializable]
    public class TimeLimitException : Exception
    {
        //基底クラスのExceptionのコンストラクタに設定するだけ
        public TimeLimitException(string message)
            : base(message)
        {
            ;
        }
    }
}