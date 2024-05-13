namespace UiParts
{
    /// <summary>
    /// コンボボックスの要素クラス
    /// </summary>
    /// <param name="Value"> 要素値 </param>
    /// <param name="DisplayText"> 表示用文字列 </param>
    /// <typeparam name="T">要素値クラス</typeparam>
    public record ComboBoxItem<T>(T Value, string DisplayText);
}
