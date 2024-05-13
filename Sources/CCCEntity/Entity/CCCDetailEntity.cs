using CccEntity.DataPacket;
using CccEntity.ValueObject;

using DomainModelCommon;

namespace CccEntity.Entity
{
    /// <summary>
    /// CCCのDetail Entity
    /// </summary>
    public class CccDetailEntity : EntityBase<CccDetailEntity>
    {
        #region Constants -------------------------------------------------------------------------------------

        /// <summary>
        /// CCC設定の初期値
        /// </summary>
        public const bool CccInitValue = false;

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
        public List<CccVO> Cccs { get; private set; } = [];

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CccDetailEntity()
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
            var list = new List<CccVO>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new(CccInitValue));
            }

            Cccs = new(list);
        }

        /// <summary>
        /// 設定データを吐き出します。
        /// </summary>
        /// <returns>設定データ</returns>
        public CccDetailPacket ExportDataPacket()
        {
            CccDetailPacket ret = new();

            foreach (var item in Cccs)
            {
                ret.Cccs.Add(item.Value);
            }

            return ret;
        }

        /// <summary>
        /// 設定データを取り込みます。
        /// </summary>
        /// <param name="packet">設定データ</param>
        public void ImportDataPacket(CccDetailPacket packet)
        {
            if (Cccs.Count != packet.Cccs.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(packet), "要素数不一致");
            }

            Cccs.Clear();

            foreach (var value in packet.Cccs)
            {
                Cccs.Add(new(value));
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
        public override CccDetailEntity Clone()
        {
            var ret = base.Clone();

            var list = new List<CccVO>();
            for (int i = 0; i < Cccs.Count; i++)
            {
                list.Add(new(Cccs[i].Value));
            }

            ret.Cccs = new(list);

            return ret;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
