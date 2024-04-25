namespace Repository
{
    /// <summary>
    /// BBBEntityのリポジトリ　インターフェース
    /// </summary>
    public interface IBBBRepository
    {
        /// <summary>
        /// BBB Entityを取得します。
        /// </summary>
        /// <returns>BBB Entity</returns>
        BBBEntity.Entity.BBBEntity Pull();

        /// <summary>
        /// BBB Entityを確定します。
        /// </summary>
        /// <param name="bbbEntity">BBBEntity</param>
        void Commit(BBBEntity.Entity.BBBEntity bbbEntity);
    }
}