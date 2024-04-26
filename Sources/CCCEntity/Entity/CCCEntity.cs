using CCCEntity.ValueObject;

using DomainModelCommon;

using System.Collections.ObjectModel;

namespace CCCEntity.Entity
{
    /// <summary>
    /// CCCのEntity
    /// </summary>
    public class CCCEntity : EntityBase<CCCEntity>
    {
        #region Constants -------------------------------------------------------------------------------------

        /// <summary>
        /// CCCsの要素数初期値
        /// </summary>
        public const int CccsCountInitValue = 100;

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// CCCのマトリクス
        /// </summary>
        public ReadOnlyCollection<CCCDetailEntity> CCCs { get; private set; } = new(new List<CCCDetailEntity>());

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CCCEntity()
        {
            ChangeCount(CccsCountInitValue);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// 要素数を変更します。
        /// </summary>
        /// <param name="count">要素数</param>
        public void ChangeCount(int count)
        {
            var list = new List<CCCDetailEntity>();
            for (int i = 0; i < count; i++)
            {
                var detail = new CCCDetailEntity();
                list.Add(detail);
            }

            CCCs = new(list);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        /// <inheritdoc/>
        public override CCCEntity Clone()
        {
            var ret = base.Clone();

            var list = new List<CCCDetailEntity>();
            for (int i = 0; i < CCCs.Count; i++)
            {
                list.Add(CCCs[i].Clone());
            }

            ret.CCCs = new(list);

            return ret;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
