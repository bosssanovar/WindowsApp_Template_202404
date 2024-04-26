using CCCEntity.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// CCCEntityのリポジトリ　インターフェース
    /// </summary>
    public interface ICCCRepository
    {
        /// <summary>
        /// CCC Entityを取得します。
        /// </summary>
        /// <returns>BBB Entity</returns>
        CCCEntity.Entity.CCCEntity Pull();

        /// <summary>
        /// CCC Entityを確定します。
        /// </summary>
        /// <param name="entity"><see cref="CCCEntity.Entity.CCCEntity"/>インスタンス</param>
        void Commit(CCCEntity.Entity.CCCEntity entity);
    }
}
