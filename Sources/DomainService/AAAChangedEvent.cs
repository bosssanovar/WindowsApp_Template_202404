using AAAEntity.DomainSreviceInterface;

namespace DomainService
{
    /// <summary>
    /// AAAEntityの設定に関連する設定値を補正するクラス
    /// </summary>
    /// <param name="_aaaEntity">AAA Entity</param>
    /// <param name="_bbbEntity">BBB Entity</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class AAAChangedEvent(AAAEntity.Entity.AAAEntity _aaaEntity, BBBEntity.Entity.BBBEntity _bbbEntity) : IAAAChangedEvent
    {
        /// <inheritdoc/>
        public void Execute()
        {
            var maxLength = _aaaEntity.AAA.Value;

            var bbb = _bbbEntity.BBB.Value;
            if (bbb.Length > maxLength)
            {
                var substring = bbb[0..maxLength];
                _bbbEntity.SetBBB(new(substring), new BBBLehgthChecker(_aaaEntity));
            }

            var bbb2 = _bbbEntity.BBB2.Value;
            if (bbb2.Length > maxLength)
            {
                var substring = bbb2[0..maxLength];
                _bbbEntity.SetBBB2(new(substring), new BBBLehgthChecker(_aaaEntity));
            }
        }
    }
}
