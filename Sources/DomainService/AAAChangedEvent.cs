using AAAEntity;
using AAAEntity.DomainSreviceInterface;

namespace DomainService
{
    public class AAAChangedEvent(AAAEntity.Entity.AAAEntity _aaaEntity, BBBEntity.Entity.BBBEntity _bbbEntity) : IAAAChangedEvent
    {
        public void Execute()
        {
            var maxLength = _aaaEntity.AAA.Value;
            var bbb = _bbbEntity.BBB.Value;

            if (bbb.Length > maxLength)
            {
                var substring = bbb[0..maxLength];
                _bbbEntity.SetBBB(new(substring), new BBBLehgthChecker(_aaaEntity));
            }
        }
    }
}
