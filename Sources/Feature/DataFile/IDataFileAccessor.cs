namespace Feature.DataFile
{
    public interface IDataFileAccessor
    {
        /// <summary>
        /// 設定をファイルに保存します。
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool Save(string content);

        /// <summary>
        /// 設定をファイルから読み込みます。
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool Load(ref string content);
    }
}
