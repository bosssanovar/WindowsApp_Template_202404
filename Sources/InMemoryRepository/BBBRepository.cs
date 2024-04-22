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

        public void Commit(BBBEntity.Entity.BBBEntity etity)
        {
            _bbbEntity = etity.Clone();
        }

        public BBBEntity.Entity.BBBEntity Pull()
        {
            return _bbbEntity.Clone();
        }
    }
}
