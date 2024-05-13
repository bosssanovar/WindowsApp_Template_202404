namespace Repository
{
    /// <summary>
    /// AAA Entityのリポジトリ　インターフェース
    /// </summary>
    public interface IAaaRepository
    {
        /// <summary>
        /// Entityを取得します。
        /// </summary>
        /// <returns>AAA Entity</returns>
        AaaEntity.Entity.AaaEntity Pull();

        /// <summary>
        /// Entityを確定します。
        /// </summary>
        /// <param name="aaaEntity">AAA Entity</param>
        void Commit(AaaEntity.Entity.AaaEntity aaaEntity);
    }
}