namespace AaaEntity.ValueObject
{
    /// <summary>
    /// XXXの種別
    /// </summary>
    public enum XxxType
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
    /// <see cref="XxxType"/>の拡張機能
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "<保留中>")]
    public static class XxxTypeExtension
    {
        /// <summary>
        /// 表示文字列を取得します。
        /// </summary>
        /// <param name="type">対象値</param>
        /// <returns>表示文字列</returns>
        public static string GetDisplayText(this XxxType type)
        {
            return type switch
            {
                XxxType.Xxx1 => "XXX 1",
                XxxType.Xxx2 => "XXX 2",
                XxxType.Xxxxxx3 => "XXXXXXX 3",
                _ => throw new NotImplementedException("実装が不足しています。"),
            };
        }
    }
}
