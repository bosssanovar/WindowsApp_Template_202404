namespace UiParts.UserControls.CccPage
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
        /// コンストラクタ
        /// </summary>
        /// <param name="text">負荷テキスト</param>
        public ColumnHeader(string text)
        {
            for (int i = 1; i <= 700; i++)
            {
                Values.Add($"{text} {i}");
            }
        }
    }
}