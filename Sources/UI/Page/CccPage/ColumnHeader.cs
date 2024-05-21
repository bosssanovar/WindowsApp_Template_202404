namespace UiParts.Page.CccPage
{
    /// <summary>
    /// 列ヘッダー
    /// </summary>
    public class ColumnHeader
    {
        /// <summary>
        /// 値
        /// </summary>
        public List<string> Values { get; } = [];

        /// <summary>
        /// コントロール幅
        /// </summary>
        public double Width { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="text">負荷テキスト</param>
        /// <param name="width">コントロール幅</param>
        public ColumnHeader(string text, double width)
        {
            Width = width;

            for (int i = 1; i <= 700; i++)
            {
                Values.Add($"{text} {i}");
            }
        }
    }
}