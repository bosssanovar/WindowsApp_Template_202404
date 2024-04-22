using Repository;

namespace InMemoryRepository
{
    public class AAARepository : IAAARepository
    {
        private AAAEntity.Entity.AAAEntity _aaaEntity;

        public AAARepository()
        {
            _aaaEntity = new AAAEntity.Entity.AAAEntity();
        }

        public void Commit(AAAEntity.Entity.AAAEntity aaaEntity)
        {
            _aaaEntity = aaaEntity.Clone();
        }

        public AAAEntity.Entity.AAAEntity Pull()
        {
            return _aaaEntity.Clone();
        }
    }
}
