using Repository;

namespace InMemoryRepository
{
    public class BBBRepository : IBBBRepository
    {
        private BBBEntity.Entity.BBBEntity _bbbEntity;

        public BBBRepository()
        {
            _bbbEntity = new BBBEntity.Entity.BBBEntity();
        }

        public void Save(BBBEntity.Entity.BBBEntity aaaEntity)
        {
            _bbbEntity = aaaEntity.Clone();
        }

        public BBBEntity.Entity.BBBEntity Load()
        {
            return _bbbEntity.Clone();
        }
    }
}
