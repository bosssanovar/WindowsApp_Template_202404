namespace Repository
{
    public interface IBBBRepository
    {
        /// <summary>
        /// BBB Entityを取得します。
        /// </summary>
        /// <returns></returns>
        BBBEntity.Entity.BBBEntity Pull();

        /// <summary>
        /// BBB Entityを確定します。
        /// </summary>
        /// <param name="aaaEntity"></param>
        void Commit(BBBEntity.Entity.BBBEntity aaaEntity);
    }
}