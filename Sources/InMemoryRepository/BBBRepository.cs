using Repository;

namespace InMemoryRepository
{
    /// <summary>
    /// BBB Entityのリポジトリ
    /// </summary>
    public class BBBRepository : IBBBRepository
    {
        private BBBEntity.Entity.BBBEntity _bbbEntity;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BBBRepository()
        {
            _bbbEntity = new BBBEntity.Entity.BBBEntity();
        }

        /// <inheritdoc/>
        public void Commit(BBBEntity.Entity.BBBEntity etity)
        {
            _bbbEntity = etity.Clone();
        }

        /// <inheritdoc/>
        public BBBEntity.Entity.BBBEntity Pull()
        {
            return _bbbEntity.Clone();
        }
    }
}
