using Repository;

namespace Usecase
{
    public class CommitSettingsUsecase(IAAARepository _aaaRepository, IBBBRepository _bbbRepository)
    {
        public void CommitAAAEntity(AAAEntity.Entity.AAAEntity entity)
        {
            _aaaRepository.Commit(entity);
        }

        public void CommitBBBEntity(BBBEntity.Entity.BBBEntity entity)
        {
            _bbbRepository.Commit(entity);
        }
    }
}
