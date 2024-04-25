namespace Repository
{
    /// <summary>
    /// AAA Entityのリポジトリ　インターフェース
    /// </summary>
    public interface IAAARepository
    {
        /// <summary>
        /// Entityを取得します。
        /// </summary>
        /// <returns>AAA Entity</returns>
        AAAEntity.Entity.AAAEntity Pull();

        /// <summary>
        /// Entityを確定します。
        /// </summary>
        /// <param name="aaaEntity">AAA Entity</param>
        void Commit(AAAEntity.Entity.AAAEntity aaaEntity);
    }
}