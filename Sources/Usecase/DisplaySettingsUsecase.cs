using Repository;

namespace Usecase
{
    public class DisplaySettingsUsecase(IAAARepository _aaaRepository, IBBBRepository _bbbRepository)
    {
        public AAAEntity.AAAEntity GetAAAEntity()
        {
            return _aaaRepository.Load();
        }

        public BBBEntity.BBBEntity GetBBBEntity()
        {
            return _bbbRepository.Load();
        }
    }
}
