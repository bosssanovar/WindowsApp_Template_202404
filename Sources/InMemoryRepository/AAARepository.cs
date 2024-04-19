using Repository;

namespace InMemoryRepository
{
    public class AAARepository : IAAARepository
    {
        private AAAEntity.AAAEntity _aaaEntity;

        public AAARepository()
        {
            _aaaEntity = new AAAEntity.AAAEntity();
        }

        public void Save(AAAEntity.AAAEntity aaaEntity)
        {
            _aaaEntity = aaaEntity.Clone();
        }

        public AAAEntity.AAAEntity Load()
        {
            return _aaaEntity.Clone();
        }
    }
}
