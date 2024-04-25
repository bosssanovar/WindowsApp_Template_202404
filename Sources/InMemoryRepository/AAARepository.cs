using Repository;

namespace InMemoryRepository
{
    /// <summary>
    /// AAAEntityのリポジトリ
    /// </summary>
    public class AAARepository : IAAARepository
    {
        private AAAEntity.Entity.AAAEntity _aaaEntity;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AAARepository()
        {
            _aaaEntity = new AAAEntity.Entity.AAAEntity();
        }

        /// <inheritdoc/>
        public void Commit(AAAEntity.Entity.AAAEntity aaaEntity)
        {
            _aaaEntity = aaaEntity.Clone();
        }

        /// <inheritdoc/>
        public AAAEntity.Entity.AAAEntity Pull()
        {
            return _aaaEntity.Clone();
        }
    }
}
