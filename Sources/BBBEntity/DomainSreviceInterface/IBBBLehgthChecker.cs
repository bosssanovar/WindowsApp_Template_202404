namespace BbbEntity.DomainSreviceInterface
{
    /// <summary>
    /// BBB設定の文字列長を確認するインターフェース
    /// </summary>
    public interface IBbbLehgthChecker
    {
        /// <summary>
        /// BBB設定の文字列長が有効かを判定します。
        /// </summary>
        /// <param name="value">対象</param>
        /// <returns>有効ならtrue</returns>
        bool IsValid(string value);
    }
}
