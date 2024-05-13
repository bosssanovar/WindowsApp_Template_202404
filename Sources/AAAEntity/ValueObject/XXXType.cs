using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAAEntity.ValueObject
{
    /// <summary>
    /// XXXの種別
    /// </summary>
    public enum XXXType
    {
        /// <summary>
        /// XXX 1
        /// </summary>
        Xxx1,

        /// <summary>
        /// XXX 2
        /// </summary>
        Xxx2,

        /// <summary>
        /// XXXXXXX 3
        /// </summary>
        Xxxxxx3,
    }

    /// <summary>
    /// <see cref="XXXType"/>の拡張機能
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "<保留中>")]
    public static class XXXTypeExtension
    {
        /// <summary>
        /// 表示文字列を取得します。
        /// </summary>
        /// <param name="type">対象値</param>
        /// <returns>表示文字列</returns>
        public static string GetDisplayText(this XXXType type)
        {
            return type switch
            {
                XXXType.Xxx1 => "XXX 1",
                XXXType.Xxx2 => "XXX 2",
                XXXType.Xxxxxx3 => "XXXXXXX 3",
                _ => throw new NotImplementedException("実装が不足しています。"),
            };
        }
    }
}
