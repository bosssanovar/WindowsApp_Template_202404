namespace Repository
{
    /// <summary>
    /// BBBEntityのリポジトリ　インターフェース
    /// </summary>
    public interface IBbbRepository
    {
        /// <summary>
        /// BBB Entityを取得します。
        /// </summary>
        /// <returns>BBB Entity</returns>
        BbbEntity.Entity.BbbEntity Pull();

        /// <summary>
        /// BBB Entityを確定します。
        /// </summary>
        /// <param name="bbbEntity">BBBEntity</param>
        void Commit(BbbEntity.Entity.BbbEntity bbbEntity);
    }
}