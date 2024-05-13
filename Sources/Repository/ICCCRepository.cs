namespace Repository
{
    /// <summary>
    /// CCCEntityのリポジトリ　インターフェース
    /// </summary>
    public interface ICccRepository
    {
        /// <summary>
        /// CCC Entityを取得します。
        /// </summary>
        /// <returns>BBB Entity</returns>
        CccEntity.Entity.CccEntity Pull();

        /// <summary>
        /// CCC Entityを確定します。
        /// </summary>
        /// <param name="entity"><see cref="CccEntity.Entity.CccEntity"/>インスタンス</param>
        void Commit(CccEntity.Entity.CccEntity entity);
    }
}
