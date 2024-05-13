using CccEntity.DataPacket;

using DomainModelCommon;

namespace CccEntity.Entity
{
    /// <summary>
    /// CCCのEntity
    /// </summary>
    public class CccEntity : EntityBase<CccEntity>
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
        public List<CccDetailEntity> Details { get; private set; } = [];

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CccEntity()
        {
            Initialize();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// 要素数を変更します。
        /// </summary>
        /// <param name="count">要素数</param>
        public void ChangeCount(int count)
        {
            var list = new List<CccDetailEntity>();
            for (int i = 0; i < count; i++)
            {
                var detail = new CccDetailEntity();
                detail.ChangeCount(count);
                list.Add(detail);
            }

            Details = new(list);
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        public void Initialize()
        {
            var list = new List<CccDetailEntity>();
            for (int i = 0; i < CccsCountInitValue; i++)
            {
                var detail = new CccDetailEntity();
                list.Add(detail);
            }

            Details = new(list);
        }

        /// <summary>
        /// 設定データを吐き出します。
        /// </summary>
        /// <returns>設定データ</returns>
        public CccEntityPacket ExportDataPacket()
        {
            CccEntityPacket ret = new();

            foreach (var item in Details)
            {
                ret.Details.Add(item.ExportDataPacket());
            }

            return ret;
        }

        /// <summary>
        /// 設定データを取り込みます。
        /// </summary>
        /// <param name="packet">設定データ</param>
        public void ImportDataPacket(CccEntityPacket packet)
        {
            if (Details.Count != packet.Details.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(packet), "要素数不一致");
            }

            for (int index = 0; index < Details.Count; index++)
            {
                Details[index].ImportDataPacket(packet.Details[index]);
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
        public override CccEntity Clone()
        {
            var ret = base.Clone();

            var list = new List<CccDetailEntity>();
            for (int i = 0; i < Details.Count; i++)
            {
                list.Add(Details[i].Clone());
            }

            ret.Details = new(list);

            return ret;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
