namespace BBBEntity.DomainSreviceInterface
{
    /// <summary>
    /// BBB設定の文字列長を確認するインターフェース
    /// </summary>
    public interface IBBBLehgthChecker
    {
        /// <summary>
        /// BBB設定の文字列長が有効化を判定します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsValid(string value);
    }
}
