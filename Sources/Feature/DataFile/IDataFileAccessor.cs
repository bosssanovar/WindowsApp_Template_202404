namespace Feature.DataFile
{
    /// <summary>
    /// 設定データのアクセス　インターフェース
    /// </summary>
    public interface IDataFileAccessor
    {
        /// <summary>
        /// 設定をファイルに保存します。
        /// </summary>
        /// <param name="content">保存する文字列</param>
        /// <returns>正常終了したらtrue</returns>
        bool Save(string content);

        /// <summary>
        /// 設定をファイルから読み込みます。
        /// </summary>
        /// <param name="content">読み込んだ文字列</param>
        /// <returns>正常終了したらtrue</returns>
        bool Load(ref string content);
    }
}
