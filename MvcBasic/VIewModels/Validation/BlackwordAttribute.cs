using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MvcBasic.VIewModels.Validation
{
    public class BlackwordAttribute : ValidationAttribute
    {
        private string _blackword;

        public BlackwordAttribute(string blackword)
        {
            this._blackword = blackword;
            this.ErrorMessage = "{0}には{1}を含むことはできません";
        }

        // プロパティの表示名と値リストでエラーエラーメッセージを整形
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture,
                                 ErrorMessageString, name, this._blackword);
        }

        // 検証
        public override bool IsValid(object value)
        {
            // 値が入力されていなければスキップ
            if(value == null)
            {
                return true;
            }

            // カンマ区切りでテキストを分解し、入力値valueと比較
            string[] list = this._blackword.Split(',');
            foreach (var item in list)
            {
                if (((string)value).Contains(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}