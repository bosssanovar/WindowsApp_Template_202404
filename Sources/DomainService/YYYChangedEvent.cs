using AAAEntity.DomainSreviceInterface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService
{
    // TODO : region追加

    /// <summary>
    /// YYY設定に関連する設定値を補正するクラス
    /// </summary>
    /// <param name="_aaaEntity"><see cref="AAAEntity.Entity.AAAEntity"/>インスタンス</param>
    /// <param name="_ccceEntity"><see cref="CCCEntity.Entity.CCCEntity"/>インスタンス</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<保留中>")]
    public class YYYChangedEvent(AAAEntity.Entity.AAAEntity _aaaEntity, CCCEntity.Entity.CCCEntity _ccceEntity) : IYYYChangedEvent
    {
        /// <inheritdoc/>
        public void Execute()
        {
            _ccceEntity.ChangeCount(_aaaEntity.YYY.Value);
        }
    }
}
