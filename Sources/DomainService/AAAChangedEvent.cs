using AAAEntity;

namespace DomainService
{
    public class AAAChangedEvent(AAAEntity.AAAEntity _aaaEntity, BBBEntity.BBBEntity _bbbEntity) : IAAAChangedEvent
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
