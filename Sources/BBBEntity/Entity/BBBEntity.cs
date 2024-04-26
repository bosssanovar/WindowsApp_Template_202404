using BBBEntity.DataPacket;
using BBBEntity.DomainSreviceInterface;
using BBBEntity.ValueObject;

namespace BBBEntity.Entity
{
    /// <summary>
    /// BBB Entityクラス
    /// </summary>
    public class BBBEntity
    {
        #region Constants -------------------------------------------------------------------------------------

        /// <summary>
        /// BBB設定の初期値
        /// </summary>
        public const string BbbInitValue = "InitValue";

        /// <summary>
        /// BBB2設定の初期値
        /// </summary>
        public const string Bbb2InitValue = "InitValue";

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// BBB設定値
        /// </summary>
        public BBBVO BBB { get; private set; }

        /// <summary>
        /// BBB2設定値
        /// </summary>
        public BBB2VO BBB2 { get; private set; }

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BBBEntity()
        {
            BBB = new(BbbInitValue);
            BBB2 = new(Bbb2InitValue);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// BBBを設定します。
        /// </summary>
        /// <param name="bbb">BBB設定値</param>
        /// <param name="checker">BBB設定値有効チェッカ</param>
        /// <exception cref="ArgumentOutOfRangeException">有効文字列長範囲外</exception>
        public void SetBBB(BBBVO bbb, IBBBLehgthChecker checker)
        {
            if (!checker.IsValid(bbb.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(bbb), "範囲外");
            }

            BBB = bbb;
        }

        /// <summary>
        /// BBB2を設定します。
        /// </summary>
        /// <param name="bbb2">BBB2設定値</param>
        /// <param name="checker">BBB2設定値有効チェッカ</param>
        /// <exception cref="ArgumentOutOfRangeException">有効文字列長範囲外</exception>
        public void SetBBB2(BBB2VO bbb2, IBBBLehgthChecker checker)
        {
            if (!checker.IsValid(bbb2.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(bbb2), "範囲外");
            }

            BBB2 = bbb2;
        }

        /// <summary>
        /// 複製します。
        /// </summary>
        /// <returns>複製したインスタンス</returns>
        public BBBEntity Clone()
        {
            // TODO K.I : Entity Clone
            return (BBBEntity)MemberwiseClone();
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        public void Initialize()
        {
            BBB = new(BbbInitValue);
            BBB2 = new(Bbb2InitValue);
        }

        /// <summary>
        /// 設定データ群を吐き出します。
        /// </summary>
        /// <returns>設定データ群</returns>
        public BBBEntityPacket ExportPacketData()
        {
            return new()
            {
                BBB = BBB.Value,
                BBB2 = BBB2.Value,
            };
        }

        /// <summary>
        /// 設定データ群を取り込みます。
        /// </summary>
        /// <param name="packet">設定データ群</param>
        public void ImportPacketData(BBBEntityPacket packet)
        {
            BBB = new(packet.BBB);
            BBB2 = new(packet.BBB2);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
