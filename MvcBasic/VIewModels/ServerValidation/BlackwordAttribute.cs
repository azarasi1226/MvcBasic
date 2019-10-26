using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace MvcBasic.ViewModels.ServerValidation
{
    public class BlackwordAttribute : ValidationAttribute, IClientValidatable
    {
        private string _blackword;

        public BlackwordAttribute(string blackword)
        {
            this._blackword = blackword;
            this.ErrorMessage = "{0}には禁止ワードを含むことはできません";
        }

        // プロパティの表示名と値リストでエラーエラーメッセージを整形
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture,
                                 ErrorMessageString, name);
        }

        // 検証
        public override bool IsValid(object value)
        {
            // 値が入力されていなければスキップ
            if (value == null)
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

        // クライアントに送信する検証情報の作成
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            // 検証ルールを準備
            var rule = new ModelClientValidationRule
            {
                ValidationType = "blackword",
                ErrorMessage = this.FormatErrorMessage(metadata.GetDisplayName())
            };

            rule.ValidationParameters["opts"] = this._blackword;
            yield return rule;
        }
    }
}