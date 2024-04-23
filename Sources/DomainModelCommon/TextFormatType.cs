namespace DomainModelCommon
{
    /// <summary>
    /// 形式種別
    /// </summary>
    public enum TextFormatType
    {
        /// <summary>
        /// 制限なし
        /// </summary>
        None,

        /// <summary>
        /// 半角英数字
        /// </summary>
        HalfWidthAlphanumeric,

        /// <summary>
        /// JIS第1水準漢字まで
        /// </summary>
        UpToJisLevel1KanjiSet,

        /// <summary>
        /// 数字(0～9))
        /// </summary>
        Number,

        /// <summary>
        /// 数値とマイナス(0～9, -)
        /// </summary>
        NumberAndMinus,

        /// <summary>
        /// 小数(0～9, 小数点)
        /// </summary>
        Decimal,

        /// <summary>
        /// 小数とマイナス(0～9, 小数点, -)
        /// </summary>
        DecimalAndMinus,
    }
}
