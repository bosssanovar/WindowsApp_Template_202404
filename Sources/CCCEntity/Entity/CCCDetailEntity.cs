using CCCEntity.ValueObject;

using DomainModelCommon;

using System.Collections.ObjectModel;

namespace CCCEntity.Entity
{
    /// <summary>
    /// CCCのDetail Entity
    /// </summary>
    public class CCCDetailEntity : EntityBase<CCCDetailEntity>
    {
        #region Constants -------------------------------------------------------------------------------------

        /// <summary>
        /// CCC設定の初期値
        /// </summary>
        public const bool CCCInitValue = false;

        /// <summary>
        /// Detailの要素数初期値
        /// </summary>
        public const int DetailCountInitValue = 100;

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// CCC Detail
        /// </summary>
        public ReadOnlyCollection<CCCVO> Detail { get; private set; } = new(new List<CCCVO>());

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CCCDetailEntity()
        {
            ChangeCount(DetailCountInitValue);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// 要素数を変更します。
        /// </summary>
        /// <param name="count">要素数</param>
        public void ChangeCount(int count)
        {
            var list = new List<CCCVO>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new(CCCInitValue));
            }

            Detail = new(list);
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
        public override CCCDetailEntity Clone()
        {
            var ret = base.Clone();

            var list = new List<CCCVO>();
            for (int i = 0; i < Detail.Count; i++)
            {
                list.Add(new(Detail[i].Value));
            }

            ret.Detail = new(list);

            return ret;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
