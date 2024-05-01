using CCCEntity.DataPacket;
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
        public List<CCCVO> CCCs { get; private set; } = [];

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

            CCCs = new(list);
        }

        /// <summary>
        /// 設定データを吐き出します。
        /// </summary>
        /// <returns>設定データ</returns>
        public CCCDetailPacket ExportDataPacket()
        {
            CCCDetailPacket ret = new();

            foreach(var item in CCCs)
            {
                ret.CCCs.Add(item.Value);
            }

            return ret;
        }

        /// <summary>
        /// 設定データを取り込みます。
        /// </summary>
        /// <param name="packet">設定データ</param>
        public void ImportDataPacket(CCCDetailPacket packet)
        {
            CCCs.Clear();

            foreach(var value in packet.CCCs)
            {
                CCCs.Add(new(value));
            }
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
            for (int i = 0; i < CCCs.Count; i++)
            {
                list.Add(new(CCCs[i].Value));
            }

            ret.CCCs = new(list);

            return ret;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
