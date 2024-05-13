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
            switch (type)
            {
                case XXXType.Xxx1:
                    return "XXX 1";
                case XXXType.Xxx2:
                    return "XXX 2";
                case XXXType.Xxxxxx3:
                    return "XXXXXXX 3";
                default:
                    throw new NotImplementedException("実装が不足しています。");
            }
        }
    }
}
