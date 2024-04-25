namespace Repository
{
    public interface IAAARepository
    {
        /// <summary>
        /// Entityを取得します。
        /// </summary>
        /// <returns></returns>
        AAAEntity.Entity.AAAEntity Pull();

        /// <summary>
        /// Entityを確定します。
        /// </summary>
        /// <param name="aaaEntity"></param>
        void Commit(AAAEntity.Entity.AAAEntity aaaEntity);
    }
}