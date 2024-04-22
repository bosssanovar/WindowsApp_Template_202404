using Repository;

namespace Usecase
{
    public class DisplaySettingsUsecase(IAAARepository _aaaRepository, IBBBRepository _bbbRepository)
    {
        public AAAEntity.Entity.AAAEntity GetAAAEntity()
        {
            return _aaaRepository.Load();
        }

        public BBBEntity.Entity.BBBEntity GetBBBEntity()
        {
            return _bbbRepository.Load();
        }
    }
}
