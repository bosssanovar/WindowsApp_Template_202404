namespace DomainModelCommon
{
    /// <summary>
    /// 設定値を制限するインターフェース
    /// </summary>
    /// <typeparam name="T">設定値の型</typeparam>
    public interface IInputLimit<T>
    {
        /// <summary>
        /// 値が有効かを判定します。
        /// </summary>
        /// <param name="value">値</param>
        /// <returns>有効な場合true</returns>
        static abstract bool IsValid(T value);

        /// <summary>
        /// 有効な値に補正します。
        /// </summary>
        /// <param name="value">設定値</param>
        /// <returns>有効な値</returns>
        static abstract T CurrectValue(T value);
    }
}
